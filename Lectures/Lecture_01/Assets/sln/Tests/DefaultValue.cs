using System;
using Xunit;

namespace Tests
{
    public class DefaultValue
    {
        static int _y;
        [Fact]
        public void Test()
        {
            int x;
            //Console.WriteLine(x);        // Compile-time error

            int[] ints = new int[2];
            Assert.Equal(0, ints[0]);

            Assert.Equal(0, _y);
        }
    }
}