using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqQuantifierOperationsTest
    {
        [Fact]
        public void AllTest()
        {
            string[] names = { "Bob", "Bill", "Bruno" };

            Assert.True(names.All(n => n.StartsWith("B")));
        }

        [Fact]
        public void AnyTest()
        {
            string[] names = { "Bob", "Ned", "Amy", "Bill" };

            Assert.True(names.Any(n => n.StartsWith("B")));
        }

        [Fact]
        public void ContainsTest()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };

            Assert.True(numbers.Contains(5));
        }
    }
}