using System;
using Xunit;

namespace Tests
{
    public class BitConverterTest
    {
        [Fact]
        public void Test()
        {
            Int32 foo = 16;
            var tmp = BitConverter.GetBytes(foo);
            var bar = BitConverter.ToInt32(tmp, 0);

            Assert.Equal(foo, bar);
        }
    }
}