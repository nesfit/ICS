using Xunit;

namespace Tests
{
    public class Continue
    {
        [Fact]
        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                if ((i % 2) == 0) // If i is even,
                {
                    continue; // continue with next iteration
                }
                Assert.True((i % 2) != 0);
            }
        }
    }
}