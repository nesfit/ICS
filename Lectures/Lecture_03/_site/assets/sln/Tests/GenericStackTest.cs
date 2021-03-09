using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GenericStackTest
    {
        [Fact]
        public void Test()
        {
            var numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");
            
            Assert.Equal("five", numbers.Pop());
        }
    }
}