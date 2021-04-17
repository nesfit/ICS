using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.TPL
{

    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
    public class ParallelLinqBenchmark
    {
        public static void Main(string[] args) => BenchmarkRunner.Run(typeof(ParallelLinqBenchmark).Assembly);

        private readonly IEnumerable<int> range;

        public ParallelLinqBenchmark() => range = Enumerable.Range(0, 2_000_000);


        [Benchmark]
        public double AverageWithUseOfParallelLinq() =>
            range.AsParallel()
                .Average();

        [Benchmark]
        public double AverageWithUseOfSerialLinq() => range.Average();

        [Benchmark]
        public IList FilteringWithUseOfParallelLinq() =>
            range.AsParallel()
                .Where(t => t % 10 == 0)
                .ToList();

        [Benchmark]
        public IList FilteringWithUseOfSerialLinq() =>
            range.Where(t => t % 10 == 0)
                .ToList();
    }
}