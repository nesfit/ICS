using Xunit;

namespace Tests
{
    public class Foreach
    {
        [Fact]
        public void Test()
        {
            var beer = "beer";
            foreach (char c in beer) // c is the iteration variable
            {
                Assert.Contains(c, beer);
            }
        }
    }
}