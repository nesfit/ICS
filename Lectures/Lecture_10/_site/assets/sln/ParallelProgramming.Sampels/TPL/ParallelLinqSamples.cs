using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ParallelProgramming.Samples.TPL
{
    public class ParallelLinqSamples
    {
        public ParallelLinqSamples(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;

        private const int RangeEnd = 20000000;

        [Fact]
        public void AverageWithUseOfParallelLinq()
        {
            var range = Enumerable.Range(0, RangeEnd);

            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            var sum = range.AsParallel()
                .Average();
            var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            output.WriteLine($"Query time: {elapsedMilliseconds} ms");
        }

        [Fact]
        public void AverageWithUseOfSerialLinq()
        {
            var range = Enumerable.Range(0, RangeEnd);

            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            var sum = range.Average();
            output.WriteLine($"Query time: {stopWatch.ElapsedMilliseconds} ms");
        }

        [Fact]
        public void FilteringWithUseOfParallelLinq()
        {
            var range = Enumerable.Range(0, RangeEnd);

            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            var variablesDivisibleBy10 = range.AsParallel()
                .Where(t => t % 10 == 0)
                .ToList();
            var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            output.WriteLine($"Query time: {elapsedMilliseconds} ms");
        }

        [Fact]
        public void FilteringWithUseOfSerialLinq()
        {
            var range = Enumerable.Range(0, RangeEnd);

            var stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            var variablesDivisibleBy10 = range.Where(t => t % 10 == 0)
                .ToList();
            output.WriteLine($"Query time: {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}