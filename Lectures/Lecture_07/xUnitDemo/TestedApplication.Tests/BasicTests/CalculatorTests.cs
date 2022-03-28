using System;
using TestedApplication.Database;
using TestedApplication.SimpleToTest;
using Xunit;

namespace TestedApplication.Tests.BasicTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Adding_2_And_5_Returns_7()
        {
            //ARRANGE
            var calculator = new Calculator();
            //ACT
            var result = calculator.Calculate(Operations.Add, 2, 5);

            //ASSERT
            Assert.Equal(7, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 2, 5)]
        [InlineData(-1, 2, 1)]
        [InlineData(-1, 1, 0)]
        public void Add_Produces_Correct_Result(int firstNumber, int secondNumber, int expectedResult)
        {
            //ARRANGE
            var calculator = new Calculator();
            //ACT
            var result = calculator.Calculate(Operations.Add, firstNumber, secondNumber);

            //ASSERT
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_With_Too_Big_Number_Throws_OverflowException()
        {
            //ARRANGE
            var calculator = new Calculator();

            //ACT + ASSERT
            Assert.Throws<OverflowException>(() =>
            {
                var result = calculator.Calculate(Operations.Add, int.MaxValue, 1);
                return result;
            });
        }

        [Fact]
        public void Sub_With_Too_Small_Number_Throws_OverflowException()
        {
            //ARRANGE
            var calculator = new Calculator();

            //ACT + ASSERT
            Assert.Throws<OverflowException>(() =>
            {
                var result = calculator.Calculate(Operations.Sub, int.MinValue, 1);
                return result;
            });
        }
    }
}