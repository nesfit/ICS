using Xunit;

namespace Tests
{
    public class Break
    {
        [Fact]
        public void Test()
        {
            int x = 0;
            while (true)
            {
                if (x++ >= 5)
                {
                    break; // break from the loop
                }
            }

            // execution continues here after break
            Assert.Equal(6, x);
        }
    }
}