using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Linq
{
    public class LinqGroupingSemanticsTest
    {
        [Fact]
        public void GroupBy_IsDeferred()
        {
            var words = new List<string> { "one", "two" };
            var grouped = words.GroupBy(w => w.Length);

            words.Add("four");

            Assert.Contains(grouped, g => g.Key == 4 && g.Contains("four"));
        }

        [Fact]
        public void ToLookup_IsImmediateSnapshot()
        {
            var words = new List<string> { "one", "two" };
            var lookup = words.ToLookup(w => w.Length);

            words.Add("four");

            Assert.Empty(lookup[4]);
        }
    }
}
