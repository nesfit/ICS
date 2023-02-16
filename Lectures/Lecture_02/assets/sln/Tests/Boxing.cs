using Xunit;

namespace Lecture02.Tests
{
    public class Boxing
    {
        [Fact]
        public void Test()
        {
            int i = 123;
            object o = i;    // Boxing
            int j = (int)o;  // Unboxing

            Assert.Equal(i, j);
        }
    }
}