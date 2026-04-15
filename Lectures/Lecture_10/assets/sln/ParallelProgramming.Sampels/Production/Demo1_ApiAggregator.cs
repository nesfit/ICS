using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

// ============================================================
// Demo 1: API Aggregator – I/O-bound concurrent calls
//
// Demonstrates:
//   - Bounded concurrency with SemaphoreSlim (no thread pool starvation)
//   - Request-level timeout budget via linked CancellationTokenSource
//   - Explicit partial-failure handling after Task.WhenAll
//   - Correct exception observation pattern (no silent swallowing)
// ============================================================

namespace ParallelProgramming.Samples.Production;

// ---------------------------------------------------------------------------
// Fake downstream service – simulates realistic async I/O latency
// ---------------------------------------------------------------------------
public static class FakeDownstreamService
{
    private static readonly Random Rng = new();

    /// <summary>Simulates a fast service (50–300 ms random latency).</summary>
    public static async Task<string> CallAsync(string name, CancellationToken token)
    {
        await Task.Delay(Rng.Next(50, 300), token);
        return $"data-from-{name}";
    }

    /// <summary>Simulates a service that always takes <paramref name="duration"/>.</summary>
    public static async Task<string> CallSlowAsync(string name, TimeSpan duration, CancellationToken token)
    {
        await Task.Delay(duration, token);
        return $"data-from-{name}";
    }
}

// ---------------------------------------------------------------------------
// Core aggregator class – the pattern students should copy into production
// ---------------------------------------------------------------------------
public sealed class ApiAggregator
{
    private readonly int _maxConcurrency;
    private readonly TimeSpan _totalBudget;

    public ApiAggregator(int maxConcurrency, TimeSpan totalBudget)
    {
        _maxConcurrency = maxConcurrency;
        _totalBudget = totalBudget;
    }

    /// <summary>
    /// Calls all services concurrently, respecting the concurrency gate and
    /// the total budget deadline.  Never throws – failures appear in the result.
    /// </summary>
    public async Task<IReadOnlyList<(string Service, string? Result, Exception? Error)>>
        AggregateAsync(IReadOnlyList<string> serviceNames, CancellationToken callerToken)
    {
        // Combine caller token with our budget deadline
        using var budgetCts = CancellationTokenSource.CreateLinkedTokenSource(callerToken);
        budgetCts.CancelAfter(_totalBudget);
        var token = budgetCts.Token;

        // Gate limits how many concurrent downstream calls are in flight
        var gate = new SemaphoreSlim(_maxConcurrency);

        var tasks = serviceNames.Select(async name =>
        {
            // Track whether we successfully acquired the gate so we only release when needed
            var acquired = false;
            try
            {
                await gate.WaitAsync(token); // may throw OperationCanceledException
                acquired = true;

                var result = await FakeDownstreamService.CallAsync(name, token);
                return (name, (string?)result, (Exception?)null);
            }
            catch (Exception ex)
            {
                // Capture all failures (including cancellation while waiting for the gate
                // or while the downstream call was in flight) – do not let one failure
                // abort all others via Task.WhenAll
                return (name, (string?)null, (Exception?)ex);
            }
            finally
            {
                if (acquired) gate.Release();
            }
        }).ToArray();

        return await Task.WhenAll(tasks);
    }
}

// ---------------------------------------------------------------------------
// Tests / live demonstrations
// ---------------------------------------------------------------------------
public class ApiAggregatorDemo(ITestOutputHelper output)
{
    [Fact]
    public async Task HappyPath_AllServicesRespond()
    {
        var aggregator = new ApiAggregator(maxConcurrency: 4, totalBudget: TimeSpan.FromSeconds(5));
        var services = Enumerable.Range(1, 5).Select(i => $"service-{i}").ToList();

        var results = await aggregator.AggregateAsync(services, CancellationToken.None);

        foreach (var r in results)
            output.WriteLine($"  {r.Service}: {r.Result ?? r.Error?.Message}");

        Assert.All(results, r =>
        {
            Assert.Null(r.Error);
            Assert.NotNull(r.Result);
        });
    }

    [Fact]
    public async Task TimeoutBudget_CancelsRemainingWork()
    {
        // Budget is 120 ms; services take 50–300 ms → some will be cut off
        var aggregator = new ApiAggregator(maxConcurrency: 2, totalBudget: TimeSpan.FromMilliseconds(120));
        var services = Enumerable.Range(1, 10).Select(i => $"service-{i}").ToList();

        var results = await aggregator.AggregateAsync(services, CancellationToken.None);

        var succeeded = results.Count(r => r.Result != null);
        var canceled  = results.Count(r => r.Error is OperationCanceledException);

        output.WriteLine($"Succeeded: {succeeded},  Canceled by budget: {canceled}");

        // At least some calls must have been cut off
        Assert.True(canceled > 0, "Expected some calls to be canceled by the timeout budget");
    }

    [Fact]
    public async Task BoundedConcurrency_PeakNeverExceedsLimit()
    {
        const int maxConcurrency = 3;

        var activeCount = 0;
        var peakCount = 0;
        var gate = new SemaphoreSlim(maxConcurrency);

        var tasks = Enumerable.Range(1, 12).Select(async i =>
        {
            await gate.WaitAsync();
            try
            {
                var current = Interlocked.Increment(ref activeCount);
                // Capture peak in a thread-safe way
                int snapshot;
                do { snapshot = peakCount; }
                while (current > snapshot &&
                       Interlocked.CompareExchange(ref peakCount, current, snapshot) != snapshot);

                await Task.Delay(40); // simulate I/O work
            }
            finally
            {
                Interlocked.Decrement(ref activeCount);
                gate.Release();
            }
        }).ToArray();

        await Task.WhenAll(tasks);

        output.WriteLine($"Peak observed: {peakCount}  (limit: {maxConcurrency})");
        Assert.True(peakCount <= maxConcurrency,
            $"Concurrency exceeded limit: {peakCount} > {maxConcurrency}");
    }

    [Fact]
    public async Task PartialFailures_AreReportedWithoutSilentSwallowing()
    {
        // Even-indexed services fail; odd-indexed succeed
        var gate = new SemaphoreSlim(4);
        var serviceNames = Enumerable.Range(0, 6).Select(i => $"service-{i}").ToList();

        var tasks = serviceNames.Select(async (name, idx) =>
        {
            await gate.WaitAsync();
            try
            {
                if (idx % 2 == 0)
                    throw new InvalidOperationException($"{name} returned HTTP 500");
                await Task.Delay(30);
                return (name, Result: (string?)$"ok-{name}", Error: (Exception?)null);
            }
            catch (Exception ex)
            {
                return (name, Result: (string?)null, Error: (Exception?)ex);
            }
            finally
            {
                gate.Release();
            }
        }).ToArray();

        var results = await Task.WhenAll(tasks);

        foreach (var r in results)
            output.WriteLine($"  {r.name}: {r.Result ?? $"ERROR – {r.Error?.Message}"}");

        // Both success and failure paths must be present
        Assert.Contains(results, r => r.Result != null);
        Assert.Contains(results, r => r.Error  != null);
    }

    [Fact]
    public async Task WithoutBoundedConcurrency_AllCallsStartImmediately()
    {
        // Contrast: no gate → all 20 tasks start at once (potential overload)
        const int count = 20;
        var started = 0;

        var tasks = Enumerable.Range(0, count).Select(async _ =>
        {
            Interlocked.Increment(ref started);
            await Task.Delay(50);
        }).ToArray();

        // All started before any awaited
        output.WriteLine($"Tasks started immediately: {started} / {count}");
        await Task.WhenAll(tasks);

        // All 20 started concurrently – no throttle, no guarantee downstream can handle it
        Assert.Equal(count, started);
    }
}
