using System;
using System.Text;
using Xunit;

namespace Tests
{
    public class ValueParameter
    {
        static void Foo(StringBuilder fooSb)
        {
            fooSb.Append("test");
            fooSb = null;
        }

        [Fact]
        public void Test()
        {
            //Arrange
            StringBuilder sb = new StringBuilder();

            //Act
            Foo(sb);

            //Assert
            Assert.Equal("test", sb.ToString());
        }
    }
}