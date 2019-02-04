using System.Linq;
using Xunit;

namespace Tests
{
    public class Array
    {
        [Fact]
        public void Test()
        {
            char[] characters = new char[5];
            char[] characters1 = new char[] { 'a', 'b', 'c' };
            char[] characters2 = { 'a', 'b', 'c' };
            
            Assert.Equal('a',characters1[0]);
            Assert.Equal('b', characters1[1]);

            for (var i = 0; i < characters1.Length; i++)
            {
                Assert.Equal(characters1[i], characters2[i]);
            }
        }
    }
}