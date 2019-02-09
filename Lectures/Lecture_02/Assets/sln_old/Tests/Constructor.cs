using Example;
using Xunit;

namespace Tests
{
    public class Constructor
    {
        [Fact]
        public void Test()
        {
            var cat = new Cat("Betty", 7);
            Assert.Equal("Betty", cat.Name);
        }
    }
}