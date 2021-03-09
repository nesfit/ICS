using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqGenerationOperationsTest
    {
        [Fact]
        public void DefaultIfEmptyTest()
        {
            string[] emptyStr = { };
            int[] emptyInt = { };
            string[] words = { "one", "two", "three" };

            Assert.True(emptyStr.DefaultIfEmpty().First() == null);
            Assert.True(emptyInt.DefaultIfEmpty().First() == 0);
            Assert.False(words.DefaultIfEmpty() == null);
        }

        [Fact]
        public void EmptyTest()
        {
            var empty = Enumerable.Empty<string>();

            Assert.True(!empty.Any());
        }

        [Fact]
        public void RangeTest()
        {
            var results = Enumerable.Range(0, 10);

            foreach (var result in results)
            {
                Assert.True(result < 10);
            }
        }

        [Fact]
        public void RepeatTest()
        {
            var word = "Banana";
            var results = Enumerable.Repeat(word, 5);

            Assert.Equal(5, results.Count());

            foreach (var result in results)
            {
                Assert.Equal("Banana", result);
            }
        }
    }
}