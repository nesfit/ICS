using Example;
using Xunit;

namespace Tests
{
    public class AsOperator
    {
        [Fact]
        public void AsOperatorTest()
        {
            var unknownCat = new UnknownCat();
            Assert.Null(unknownCat as Cat);
        }
    }
}