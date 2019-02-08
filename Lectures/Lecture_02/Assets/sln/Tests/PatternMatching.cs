using Example;
using Xunit;

namespace Tests
{
    public class PatternMatching
    {
        [Fact]
        public void WithoutPatternMatchingTest()
        {
            var unknownCat = new UnknownCat();
            if (unknownCat is Cat)
            {
                Assert.NotNull(unknownCat as Cat);
            }
            Assert.Null(unknownCat as Cat);
        }

        [Fact]
        public void PatternMatchingTest()
        {
            var unknownCat = new UnknownCat();
            if (unknownCat is Cat cat)
            {
                Assert.NotNull(cat);
            }
        }
    }
}