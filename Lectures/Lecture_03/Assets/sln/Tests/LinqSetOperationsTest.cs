using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqSetOperationsTest
    {
        [Fact]
        public void DistinctTest()
        {
            int[] numbers = { 1, 2, 2, 3, 4, 5, 6, 6, 6, 7, 8, 9 };

            var result = numbers.Distinct();

            Assert.Equal(9, result.Count());
        }

        [Fact]
        public void ExceptTest()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Except(numbers2);

            Assert.Equal(2, result.Count());
            Assert.Contains(1, result);
            Assert.Contains(2, result);
        }

        [Fact]
        public void IntersectTest()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Intersect(numbers2);

            Assert.Equal(1, result.Count());
            Assert.Contains(3, result);
        }

        [Fact]
        public void UnionTest()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 3, 4, 5 };

            var result = numbers1.Union(numbers2);

            Assert.Equal(5, result.Count());
        }
    }
}