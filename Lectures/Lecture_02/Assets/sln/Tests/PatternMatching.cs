using System.Diagnostics.CodeAnalysis;
using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class PatternMatching
    {
        [Fact]
        public void WithoutPatternMatchingTest()
        {
            WildCat unknownCat = new WildCat();
            if (unknownCat is Cat)
            {
                Assert.NotNull(unknownCat as Cat);
            }
            Assert.Null(unknownCat as Cat);
        }

        [Fact]
        public void PatternMatchingTest()
        {
            WildCat unknownCat = new WildCat();
            if (unknownCat is Cat cat)
            {
                Assert.NotNull(cat);
            }
        }
    }
}