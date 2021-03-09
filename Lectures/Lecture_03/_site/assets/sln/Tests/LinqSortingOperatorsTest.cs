using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqSortingOperatorsTest
    {
        [Fact]
        public void OrderByTest()
        {
            int[] numbers = { 7, 9, 5 };
            var result = numbers.OrderBy(n => n);

            Assert.Equal(5, result.First());
            Assert.Equal(9, result.Last());
        }

        [Fact]
        public void OrderByDecresingTest()
        {
            int[] numbers = { 7, 9, 5 };
            var result = numbers.OrderByDescending(n => n);

            Assert.Equal(9, result.First());
            Assert.Equal(5, result.Last());
        }

        [Fact]
        public void ReverseTest()
        {
            int[] numbers = { 7, 9, 5 };
            var result = numbers.Reverse();

            Assert.Equal(5, result.First());
            Assert.Equal(7, result.Last());
        }

        [Fact]
        public void ThenByTest()
        {
            string[] capitals = { "Berlin", "Paris", "Madrid", "Tokyo", "London",
                "Athens", "Beijing", "Seoul" };

            // First by length and second by alphabetical
            var result = capitals.OrderBy(c => c.Length).ThenBy(c => c);

            Assert.Equal("Paris", result.First());
            Assert.Equal("Beijing", result.Last());
        }
    }
}