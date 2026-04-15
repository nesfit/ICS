using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

// ============================================================
// Demo 3: Channel<T> Producer-Consumer Pipeline
//
// Demonstrates:
//   - Channel.CreateBounded with BoundedChannelFullMode.Wait (backpressure)
//   - Multiple parallel consumers
//   - Graceful shutdown via CancellationToken
//   - Throughput measurement and queue-depth snapshots
//   - Why bounded channels prevent out-of-memory under bursty producer load
// ============================================================

namespace ParallelProgramming.Samples.Production;

// ---------------------------------------------------------------------------
// Domain types
// ---------------------------------------------------------------------------

public record Job(int Id, string Payload);

public record JobResult(int JobId, string Output);

// ---------------------------------------------------------------------------
// Processing helper
// ---------------------------------------------------------------------------

public static class JobProcessor
{
    /// <summary>Simulates async processing work (I/O + light CPU).</summary>
    public static async Task<JobResult> ProcessAsync(Job job, CancellationToken token)
    {
        await Task.Delay(10, token); // simulate async work
        return new JobResult(job.Id, $"processed-{job.Id}");
    }
}

// ---------------------------------------------------------------------------
// Tests / live demonstrations
// ---------------------------------------------------------------------------

public class ChannelPipelineDemo(ITestOutputHelper output)
{
    // ---------------------------------------------------------------------------
    // 1. Basic producer-consumer: all jobs are produced and consumed exactly once
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task BasicProducerConsumer_AllJobsConsumed()
    {
        const int jobCount  = 40;
        const int consumers = 4;

        // Bounded channel acts as a buffer; Full=Wait creates backpressure on producer
        var channel = Channel.CreateBounded<Job>(new BoundedChannelOptions(10)
        {
            FullMode            = BoundedChannelFullMode.Wait,
            SingleWriter        = true,
            SingleReader        = false
        });

        var consumed = 0;

        // Single producer
        var producer = Task.Run(async () =>
        {
            for (var i = 0; i < jobCount; i++)
                await channel.Writer.WriteAsync(new Job(i, $"payload-{i}"));

            // Signal: no more items will be written
            channel.Writer.Complete();
        });

        // Multiple consumers – ReadAllAsync stops automatically when channel is complete
        var consumerTasks = Enumerable.Range(0, consumers).Select(_ => Task.Run(async () =>
        {
            await foreach (var job in channel.Reader.ReadAllAsync())
            {
                await JobProcessor.ProcessAsync(job, CancellationToken.None);
                Interlocked.Increment(ref consumed);
            }
        })).ToArray();

        await producer;
        await Task.WhenAll(consumerTasks);

        output.WriteLine($"Produced: {jobCount},  Consumed: {consumed}");
        Assert.Equal(jobCount, consumed);
    }

    // ---------------------------------------------------------------------------
    // 2. Backpressure: bounded channel throttles a faster producer
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task Backpressure_ThrottlesProducerWhenChannelFull()
    {
        const int capacity = 5;

        var channel = Channel.CreateBounded<Job>(new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        });

        // Slow consumer – takes 30 ms per job
        var consumer = Task.Run(async () =>
        {
            await foreach (var job in channel.Reader.ReadAllAsync())
                await Task.Delay(30);
        });

        // Fast producer – records how long each write took
        var sw = Stopwatch.StartNew();
        var firstWriteMs  = 0L;
        var lastWriteMs   = 0L;

        for (var i = 0; i < 20; i++)
        {
            // WriteAsync blocks here when channel is full → backpressure in action
            await channel.Writer.WriteAsync(new Job(i, $"p-{i}"));

            if (i == 0)  firstWriteMs = sw.ElapsedMilliseconds;
            if (i == 19) lastWriteMs  = sw.ElapsedMilliseconds;
        }

        channel.Writer.Complete();
        await consumer;

        var totalDurationMs = lastWriteMs - firstWriteMs;
        output.WriteLine($"Producer write span: {totalDurationMs} ms  (channel capacity: {capacity})");
        output.WriteLine("→ Producer was slowed by backpressure when channel was full");

        // With capacity=5 and consumer latency of 30 ms, producer must wait multiple times
        Assert.True(totalDurationMs > 50, "Expected producer to be significantly throttled");
    }

    // ---------------------------------------------------------------------------
    // 3. Graceful shutdown: cancellation stops both producer and consumers cleanly
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task GracefulShutdown_CancellationStopsPipelineCleanly()
    {
        using var cts = new CancellationTokenSource();
        var processedCount = 0;

        var channel = Channel.CreateBounded<Job>(50);

        // Infinite producer – writes until canceled
        var producer = Task.Run(async () =>
        {
            for (var i = 0; ; i++)
            {
                try
                {
                    await channel.Writer.WriteAsync(new Job(i, $"p-{i}"), cts.Token);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            // Signal completion so consumers can drain and exit
            channel.Writer.TryComplete();
        });

        // Consumer – exits when channel is complete or token is canceled
        var consumer = Task.Run(async () =>
        {
            try
            {
                await foreach (var job in channel.Reader.ReadAllAsync(cts.Token))
                {
                    await JobProcessor.ProcessAsync(job, cts.Token);
                    Interlocked.Increment(ref processedCount);
                }
            }
            catch (OperationCanceledException) { /* expected clean exit path */ }
        });

        // Let the pipeline run briefly, then cancel
        await Task.Delay(200);
        cts.Cancel();

        await Task.WhenAll(producer, consumer);

        output.WriteLine($"Processed {processedCount} jobs before cancellation");
        Assert.True(processedCount > 0, "Expected at least some jobs to complete before cancel");
    }

    // ---------------------------------------------------------------------------
    // 4. Throughput measurement with queue-depth snapshots
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task Throughput_MeasuredWithQueueDepthSnapshots()
    {
        const int jobCount   = 300;
        const int consumers  = 4;
        const int bufferSize = 50;

        var channel = Channel.CreateBounded<Job>(new BoundedChannelOptions(bufferSize)
        {
            FullMode     = BoundedChannelFullMode.Wait,
            SingleWriter = true,
            SingleReader = false
        });

        var processedCount = 0;
        var sw = Stopwatch.StartNew();

        // Producer
        var producer = Task.Run(async () =>
        {
            for (var i = 0; i < jobCount; i++)
                await channel.Writer.WriteAsync(new Job(i, $"p-{i}"));
            channel.Writer.Complete();
        });

        // Consumers with periodic queue-depth snapshots
        var workers = Enumerable.Range(0, consumers).Select(workerId => Task.Run(async () =>
        {
            await foreach (var job in channel.Reader.ReadAllAsync())
            {
                await JobProcessor.ProcessAsync(job, CancellationToken.None);
                var count = Interlocked.Increment(ref processedCount);

                if (count % 100 == 0)
                {
                    output.WriteLine(
                        $"  {count,4} processed | " +
                        $"queue depth: {channel.Reader.Count,3} | " +
                        $"elapsed: {sw.ElapsedMilliseconds} ms");
                }
            }
        })).ToArray();

        await producer;
        await Task.WhenAll(workers);
        sw.Stop();

        var throughput = jobCount / (sw.ElapsedMilliseconds / 1000.0);
        output.WriteLine("");
        output.WriteLine($"Total: {processedCount} jobs in {sw.ElapsedMilliseconds} ms " +
                         $"≈ {throughput:F0} jobs/sec  (consumers: {consumers})");

        Assert.Equal(jobCount, processedCount);
    }

    // ---------------------------------------------------------------------------
    // 5. Unbounded vs bounded: shows memory risk without backpressure
    // ---------------------------------------------------------------------------

    [Fact]
    public async Task Unbounded_Channel_AcceptsAllItemsImmediately()
    {
        // Unbounded: producer never blocks → risk of unbounded memory growth
        var channel = Channel.CreateUnbounded<Job>(new UnboundedChannelOptions
        {
            SingleWriter = true,
            SingleReader = false
        });

        const int jobCount = 500;
        var sw = Stopwatch.StartNew();

        // Producer writes all jobs without any consumer running yet
        for (var i = 0; i < jobCount; i++)
            channel.Writer.TryWrite(new Job(i, $"p-{i}"));

        channel.Writer.Complete();

        output.WriteLine($"Wrote {jobCount} items to unbounded channel in {sw.ElapsedMilliseconds} ms");
        output.WriteLine($"Queue depth before any consumer: {channel.Reader.Count}");
        output.WriteLine("→ With a slow consumer this would grow without bound");

        // Now drain
        var consumed = 0;
        await foreach (var _ in channel.Reader.ReadAllAsync())
            consumed++;

        Assert.Equal(jobCount, consumed);
    }
}
