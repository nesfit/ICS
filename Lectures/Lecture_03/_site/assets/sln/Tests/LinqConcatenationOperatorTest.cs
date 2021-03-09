using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqConcatenationOperatorTest
    {
        [Fact]
        public void ContatTest()
        {
            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 4, 5, 6 };

            var result = numbers1.Concat(numbers2);

            Assert.Equal(6, result.Count());
            Assert.Contains(1, result);
            Assert.Contains(4, result);
        }
    }
}