using System;
using Xunit;

namespace Tests
{
    public class ConvertTest
    {
        [Fact]
        public void Test()
        {
            double doubleNumber = 23.15;
            int intNumber = Convert.ToInt32(doubleNumber);
            bool boolNumber = Convert.ToBoolean(doubleNumber);
            string stringNumber = Convert.ToString(doubleNumber);
            char charNumber = Convert.ToChar(stringNumber[0]);

            Assert.Equal(23, intNumber);
            Assert.True(boolNumber);
            Assert.Equal("23.15", stringNumber);
            Assert.Equal('2', charNumber);
        }
    }
}