using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqAggregationOperatorsTest
    {
        [Fact]
        public void AggregateTest()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            var result = numbers.Aggregate((a, b) => a * b);

            Assert.Equal(120, result);
        }

        [Fact]
        public void AverageTest()
        {
            int[] numbers = { 10, 10, 11, 12, 12 };

            var result = numbers.Average();

            Assert.Equal(11, result);
        }

        [Fact]
        public void CountTest()
        {
            string[] names = { "Peter", "John", "Kathlyn", "Allen", "Tim" };

            var result = names.Count();

            Assert.Equal(5, result);
        }

        [Fact]
        public void LongCountTest()
        {
            // Create array which is 5 elements larger than Int32.MaxValue
            var largeArr = Enumerable.Range(0, Int32.MaxValue).Concat(Enumerable.Range(0, 5));

            Int64 result = largeArr.LongCount();

            Assert.Equal(((Int64)Int32.MaxValue) + 5, result);
        }

        [Fact]
        public void MaxTest()
        {
            int[] numbers = { 2, 8, 5, 6, 1 };

            var result = numbers.Max();

            Assert.Equal(8, result);
        }

        [Fact]
        public void MinTest()
        {
            int[] numbers = { 6, 9, 3, 7, 5 };

            var result = numbers.Min();

            Assert.Equal(3, result);
        }

        [Fact]
        public void SumTest()
        {
            int[] numbers = { 2, 5, 10 };

            var result = numbers.Sum();

            Assert.Equal(17, result);
        }
    }
}