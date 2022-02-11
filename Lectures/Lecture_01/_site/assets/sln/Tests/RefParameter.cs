using Xunit;

namespace Tests
{
    public class RefParameter
    {
        private void Foo(ref int p)
        {
            p = p + 1;          // Increment p by 1
        }

        [Fact]
        public void Test()
        {
            int x = 8;
            Foo(ref x);           // Ask Foo to deal directly with x
            Assert.Equal(9, x);
        }
    }
}