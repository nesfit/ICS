using Xunit;

#pragma warning disable CS0162 // Unreachable code detected

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
                Assert.True(false, "never happens");
            }
        }
    }
}
