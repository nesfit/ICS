using Xunit;

namespace Tests
{
    public class While
    {
        [Fact]
        public void Test()
        {
            int i = 0;
            while (i < 3)
            {
                Assert.True(i < 3);
                i++;
            }
            Assert.Equal(3, i);
        }
    }
}