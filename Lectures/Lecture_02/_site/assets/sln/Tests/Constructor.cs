using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class Constructor
    {
        [Fact]
        public void Test()
        {
            Cat cat = new Cat("Betty", 7);

            Assert.Equal("Betty", cat.Name);
        }
    }
}