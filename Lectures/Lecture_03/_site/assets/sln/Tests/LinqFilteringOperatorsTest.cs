using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqFilteringOperatorsTest
    {
        [Fact]
        public void WhereTest()
        {
            var names = new List<string> { "Bill", "Steve", "Ram", "Moin", "Mike" };
            var result = names.Where(n => n.StartsWith("M"));

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void OfTypeTest()
        {
            var names = new List<object> { "Bill", "Steve", 2, 't', "Mike" };
            var result = names.OfType<string>();

            Assert.Equal(3, result.Count());
        }
    }
}