using Xunit;

namespace Tests
{
    public class TernaryOperand
    {
        [Fact]
        public void Test()
        {
            int x = 20, y = 10;
            var result = x > y ? 30 : 40;
            Assert.Equal(30, result);
        }
    }
}