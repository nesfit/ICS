using Xunit;

namespace Tests
{
    public class If
    {
        [Fact]
        public void Test()
        {
            if (5 < 2 * 3)
            {
                Assert.True(5 < 2 * 3);
            }
            else
            {
                Assert.False(5 < 2 * 3);
            }
        }
    }
}