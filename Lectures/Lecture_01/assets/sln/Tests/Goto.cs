using Xunit;

namespace Tests
{
    public class Goto
    {
        [Fact]
        public void Test()
        {
            int i = 1;
            startLoop:
            if (i <= 5)
            {
                Assert.True(i <= 5);
                i++;
                goto startLoop;
            }
        }
    }
}