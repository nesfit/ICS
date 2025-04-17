using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

namespace ParallelProgramming.Samples.TPL
{

    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 5, targetCount: 5, id: "FastAndDirtyJob")]
    public class ParallelLinqBenchmark
    {
        public static void Main(string[] args) => BenchmarkRunner.Run(typeof(ParallelLinqBenchmark).Assembly);

        private readonly IEnumerable<int> _range = Enumerable.Range(0, 200_000_000);

        [Benchmark]
        public double AverageWithUseOfParallelLinq() =>
            _range.AsParallel()
                .Average();

        [Benchmark]
        public double AverageWithUseOfSerialLinq() => _range.Average();

        [Benchmark]
        public IList FilteringWithUseOfParallelLinq() =>
            _range.AsParallel()
                .Where(t => t % 10 == 0)
                .ToList();

        [Benchmark]
        public IList FilteringWithUseOfSerialLinq() =>
            _range.Where(t => t % 10 == 0)
                .ToList();
    }
}