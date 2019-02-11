using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class PatternMatching
    {
        [Fact]
        public void WithoutPatternMatchingTest()
        {
            var unknownCat = new WildCat();
            if (unknownCat is Cat)
            {
                Assert.NotNull(unknownCat as Cat);
            }
            Assert.Null(unknownCat as Cat);
        }

        [Fact]
        public void PatternMatchingTest()
        {
            var unknownCat = new WildCat();
            if (unknownCat is Cat cat)
            {
                Assert.NotNull(cat);
            }
        }
    }
}