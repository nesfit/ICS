using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GenericQueueTest
    {
        [Fact]
        public void Test()
        {
            var numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            Assert.Equal("one", numbers.Dequeue());
        }
    }
}