using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqGroupingOperatorsTest
    {
        [Fact]
        public void GroupByTest()
        {
            int[] numbers = { 10, 15, 20, 25, 30, 35 };

            var result = numbers.GroupBy(n => (n % 10 == 0));

            foreach (var group in result)
            {
                foreach (var number in group)
                {
                    if (group.Key == true)
                    {
                        Assert.True(number % 10 == 0);
                    }
                    else
                    {
                        Assert.True(number % 10 != 0);
                    }
                }
            }
        }

        [Fact]
        public void ToLookupTest()
        {
            string[] words = { "one", "two", "three", "four", "five", "six", "seven" };

            var result = words.ToLookup(w => w.Length);

            Assert.Contains("one", result[3]);
            Assert.Contains("two", result[3]);
            Assert.Contains("four", result[4]);
            Assert.Contains("five", result[4]);
            Assert.Contains("seven", result[5]);
        }
    }
}