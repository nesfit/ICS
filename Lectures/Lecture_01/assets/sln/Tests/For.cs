using Xunit;

namespace Tests
{
    public class For
    {
        [Fact]
        public void Test()
        {
            for (int i = 0; i < 3; i++)
            {
                Assert.True(i < 3);
            }
        }
    }
}