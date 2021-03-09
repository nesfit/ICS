using Xunit;

namespace Tests
{
    public class DoWhile
    {
        [Fact]
        public void Test()
        {
            int i = 0;
            do
            {
                Assert.True(i < 3);
                i++;
            } while (i < 3);
        }
    }
}