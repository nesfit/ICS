using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace Tests.Linq.Gotchas
{
    public class LinqCastingPitfallsTest
    {
        [Fact]
        public void Cast_ThrowsWhenSequenceContainsIncompatibleElement()
        {
            IEnumerable mixed = new object[] { "one", 2, "three" };

            Assert.Throws<InvalidCastException>(() => mixed.Cast<string>().ToList());
        }

        [Fact]
        public void OfType_FiltersOutIncompatibleElements()
        {
            IEnumerable mixed = new object[] { "one", 2, "three", null };
            var strings = mixed.OfType<string>().ToList();

            Assert.Equal(new[] { "one", "three" }, strings);
        }
    }
}
