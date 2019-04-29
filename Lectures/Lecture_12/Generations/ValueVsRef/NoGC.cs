using System;
using BenchmarkDotNet.Attributes;

namespace ValueVsRef
{
    [Config(typeof(AllocationsConfig))]
    public class NoGC
    {
        [Benchmark(Baseline = true)]
        public ValueTuple<int, int> CreateValueTuple() => ValueTuple.Create(0, 0);

        [Benchmark]
        public Tuple<int, int> CreateTuple() => Tuple.Create(0, 0);
    }
}