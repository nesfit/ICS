using Xunit;

namespace Tests
{
    public class InParameter
    {
        private void Foo(in int p)
        {
            // Uncomment the following line to see error 
            //p = 19;
        }

        [Fact]
        public void Test()
        {
            int x = 8;
            Foo(x);           
            Assert.Equal(8, x);
        }
    }
}