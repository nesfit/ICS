using Example;
using Xunit;

namespace Tests
{
    public class IsOperator
    {
        [Fact]
        public void IsOperatorTest()
        {
            var unknownCat = new UnknownCat();
            Assert.False(unknownCat is Cat);
        }
    }
}