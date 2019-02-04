using Xunit;

namespace Tests
{
    public class NullableType
    {
        [Fact]
        public void Test()
        {
            int? x = null;
            int? y = 7;
            
            Assert.Null(x);
            Assert.NotNull(y);
        }
    }
}