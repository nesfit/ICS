using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqPartitionOperatorsTest
    {
        [Fact]
        public void SkipTest()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.Skip(4);

            Assert.DoesNotContain("one", result);
            Assert.DoesNotContain("two", result);
            Assert.Contains("five", result);
            Assert.Contains("six", result);
        }

        [Fact]
        public void SkipWhileTest()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.SkipWhile(w => w.Length == 3);

            Assert.DoesNotContain("one", result);
            Assert.DoesNotContain("two", result);
            Assert.Contains("three", result);
            Assert.Contains("six", result);
        }

        [Fact]
        public void TakeTest()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.Take(4);

            Assert.Contains("one", result);
            Assert.Contains("two", result);
            Assert.DoesNotContain("five", result);
            Assert.DoesNotContain("six", result);
        }

        [Fact]
        public void TakeWhileTest()
        {
            string[] words = { "one", "two", "three", "four", "five", "six" };

            var result = words.TakeWhile(w => w.Length == 3);

            Assert.Contains("one", result);
            Assert.Contains("two", result);
            Assert.DoesNotContain("three", result);
            Assert.DoesNotContain("six", result);
        }
    }
}