using System;
using Xunit;

namespace Tests
{
    public class Return
    {
        static double CalculateArea(int r)
        {
            double area = r * r * Math.PI;
            return area;
        }

        [Fact]
        public void Test()
        {
            int radius = 5;
            double result = CalculateArea(radius);
            double expectedResult = radius * radius * Math.PI;
            Assert.Equal(result, expectedResult);
        }
    }
}