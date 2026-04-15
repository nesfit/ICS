using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Xunit;
using Xunit.Abstractions;

// ============================================================
// Demo 2: CPU Batch Processing
//
// Demonstrates:
//   - Serial baseline for reference
//   - Parallel.ForEach with default and explicit degree of parallelism
//   - PLINQ as an alternative to Parallel.ForEach
//   - Async vs Parallel for I/O-bound work (async wins)
//   - Measuring where parallelism overhead starts to pay off
// ============================================================

namespace ParallelProgramming.Samples.Production;

public class CpuBatchDemo(ITestOutputHelper output)
{
    // ---------------------------------------------------------------------------
    // Simulated CPU-bound work
    // (math operations chosen to be fast enough for a test yet heavy enough
    //  that multiple items across all logical cores produce a measurable speedup)
    // ---------------------------------------------------------------------------

    private static double ExpensiveComputation(int value)
    {
        var result = 0.0;
        for (var i = 1; i <= 8_000; i++)
            result += Math.Sqrt(value * i + 1.0) / i;
        return result;
    }

    private static readonly IReadOnlyList<int> Dataset =
        Enumerable.Range(0, 4_000).ToList();

    // ---------------------------------------------------------------------------
    // 1. Serial baseline
    // ---------------------------------------------------------------------------

    [Fact]
    public void Serial_Baseline()
    {
        var sw = Stopwatch.StartNew();
        var results = Dataset.Select(ExpensiveComputation).ToList();
        output.WriteLine($"[Serial]  {sw.ElapsedMilliseconds,5} ms  |  items: {results.Count}");
    }

    // ---------------------------------------------------------------------------
    // 2. Parallel.ForEach with default degree of parallelism (= logical CPU count)
    // ---------------------------------------------------------------------------

    [Fact]
    public void Parallel_ForEach_DefaultDop()
    {
        var results = new ConcurrentBag<double>();
        var sw = Stopwatch.StartNew();

        Parallel.ForEach(Dataset, item => results.Add(ExpensiveComputation(item)));

        output.WriteLine(
            $"[Parallel.ForEach DOP=default({Environment.ProcessorCount})]" +
            $"  {sw.ElapsedMilliseconds,5} ms  |  items: {results.Count}");
    }

    // ---------------------------------------------------------------------------
    // 3. PLINQ – declarative parallel alternative
    // ---------------------------------------------------------------------------

    [Fact]
    public void PLINQ_DefaultDop()
    {
        var sw = Stopwatch.StartNew();
        var results = Dataset.AsParallel()
                             .Select(ExpensiveComputation)
                             .ToList();
        output.WriteLine(
            $"[PLINQ   DOP=default({Environment.ProcessorCount})]" +
            $"  {sw.ElapsedMilliseconds,5} ms  |  items: {results.Count}");
    }

    // ---------------------------------------------------------------------------
    // 4. Explicit degree-of-parallelism sweep
    //    Shows the sweet spot: beyond logical CPU count there is no further gain
    // ---------------------------------------------------------------------------

    [Fact]
    public void Parallel_ExplicitDop_Sweep()
    {
        output.WriteLine($"Logical processors on this machine: {Environment.ProcessorCount}");
        output.WriteLine("");

        var degreesToTest = new[] { 1, 2, 4, Environment.ProcessorCount, Environment.ProcessorCount * 2 }
            .Distinct()
            .OrderBy(d => d);

        foreach (var dop in degreesToTest)
        {
            var results = new ConcurrentBag<double>();
            var sw = Stopwatch.StartNew();

            Parallel.ForEach(
                Dataset,
                new ParallelOptions { MaxDegreeOfParallelism = dop },
                item => results.Add(ExpensiveComputation(item)));

            output.WriteLine($"  DOP={dop,3}:  {sw.ElapsedMilliseconds,5} ms");
        }
    }

    // ---------------------------------------------------------------------------
    // 5. Small-collection overhead trap
    //    Shows that for tiny datasets parallel thread-scheduling can be slower
    // ---------------------------------------------------------------------------

    [Fact]
    public void SmallCollection_ParallelOverhead_CanBeSlow()
    {
        var smallDataset = Enumerable.Range(0, 20).ToList();

        var sw = Stopwatch.StartNew();
        var serial = smallDataset.Select(ExpensiveComputation).ToList();
        var serialMs = sw.ElapsedMilliseconds;

        sw.Restart();
        var parallel = new ConcurrentBag<double>();
        Parallel.ForEach(smallDataset, item => parallel.Add(ExpensiveComputation(item)));
        var parallelMs = sw.ElapsedMilliseconds;

        output.WriteLine($"[Small dataset: 20 items]");
        output.WriteLine($"  Serial:   {serialMs,5} ms");
        output.WriteLine($"  Parallel: {parallelMs,5} ms");
        output.WriteLine(serialMs <= parallelMs
            ? "  → Serial wins (parallel overhead > gain)"
            : "  → Parallel wins");
    }

    // ---------------------------------------------------------------------------
    // 6. Async vs Parallel for I/O-bound work
    //    Demonstrates why you should NOT use Parallel.ForEach for I/O waits
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task IoBound_Async_Beats_Parallel()
    {
        const int items   = 80;
        const int delayMs = 20; // simulate a network hop

        // Parallel approach: each thread blocks on .Wait() → wastes thread pool threads
        var sw = Stopwatch.StartNew();
        Parallel.For(0, items, _ => Task.Delay(delayMs).Wait());
        var parallelMs = sw.ElapsedMilliseconds;

        // Async approach: threads are free while awaiting → far fewer threads needed
        sw.Restart();
        var asyncTasks = Enumerable.Range(0, items)
                                   .Select(_ => Task.Delay(delayMs));
        await Task.WhenAll(asyncTasks);
        var asyncMs = sw.ElapsedMilliseconds;

        output.WriteLine($"[I/O-bound, {items} items, {delayMs} ms simulated latency each]");
        output.WriteLine($"  Parallel (blocking .Wait()): {parallelMs,5} ms");
        output.WriteLine($"  Async   (non-blocking await): {asyncMs,5} ms");
        output.WriteLine($"  Async speedup: ~{(double)parallelMs / Math.Max(asyncMs, 1):F1}x");

        // Async should be significantly faster here
        Assert.True(asyncMs < parallelMs,
            "Expected async to outperform blocking parallel for pure I/O-bound work");
    }
}

// ---------------------------------------------------------------------------
// BenchmarkDotNet class – run via project entry point for accurate numbers
// Picked up automatically by BenchmarkRunner.Run(assembly) in Program.cs
// ---------------------------------------------------------------------------

[SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 3, targetCount: 5,
    id: "CpuBatchJob")]
public class CpuBatchBenchmark
{
    private static double ExpensiveComputation(int value)
    {
        var result = 0.0;
        for (var i = 1; i <= 8_000; i++)
            result += Math.Sqrt(value * i + 1.0) / i;
        return result;
    }

    private static readonly IReadOnlyList<int> Dataset =
        Enumerable.Range(0, 4_000).ToList();

    [Benchmark(Baseline = true)]
    public List<double> Serial() =>
        Dataset.Select(ExpensiveComputation).ToList();

    [Benchmark]
    public List<double> ParallelForEach_DefaultDop()
    {
        var bag = new ConcurrentBag<double>();
        Parallel.ForEach(Dataset, item => bag.Add(ExpensiveComputation(item)));
        return bag.ToList();
    }

    [Benchmark]
    public List<double> Plinq_DefaultDop() =>
        Dataset.AsParallel().Select(ExpensiveComputation).ToList();
}
