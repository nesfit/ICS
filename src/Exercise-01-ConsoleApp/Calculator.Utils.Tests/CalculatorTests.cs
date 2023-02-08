using System;
using Xunit;

namespace Calculator.Utils.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(int.MinValue, int.MaxValue, -1)]
    public void Add_CorrectResult(int operand1, int operand2, int expectedResult)
    {
        int computedResult = Calculator.Add(operand1, operand2);
        Assert.Equal(expectedResult, computedResult);
    }

    [Theory]
    [InlineData(MathOperation.Addition, 1, 1, 2)]
    [InlineData(MathOperation.Addition, -1, 1, 0)]
    [InlineData(MathOperation.Addition, 0, 0, 0)]
    [InlineData(MathOperation.Addition, int.MinValue, int.MaxValue, -1)]
    [InlineData(MathOperation.Subtraction, 1, 1, 0)]
    [InlineData(MathOperation.Subtraction, -1, 1, -2)]
    [InlineData(MathOperation.Subtraction, 0, 0, 0)]
    [InlineData(MathOperation.Subtraction, int.MinValue, int.MaxValue, 1)]
    [InlineData(MathOperation.Division, 1, 1, 1)]
    [InlineData(MathOperation.Division, -1, 1, -1)]
    [InlineData(MathOperation.Division, int.MinValue, int.MaxValue, -1)]
    [InlineData(MathOperation.Multiplication, 1, 1, 1)]
    [InlineData(MathOperation.Multiplication, -1, 1, -1)]
    [InlineData(MathOperation.Multiplication, 0, 0, 0)]
    [InlineData(MathOperation.Multiplication, int.MinValue, int.MaxValue, int.MinValue)]
    public void Calculate_CorrectResult(MathOperation mathOperation, int operand1, int operand2, int expectedResult)
    {
        int computedResult = Calculator.Calculate(operand1, operand2, mathOperation);
        Assert.Equal(expectedResult, computedResult);
    }

    [Fact]
    public void Calculate_Division_ByZero_Throws() =>
        Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(1, 0, MathOperation.Division));

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(-1, 1, -2)]
    [InlineData(0, 0, 0)]
    [InlineData(int.MinValue, int.MaxValue, 1)]
    public void Subtract_CorrectResult(int operand1, int operand2, int expectedResult)
    {
        int computedResult = Calculator.Subtract(operand1, operand2);
        Assert.Equal(expectedResult, computedResult);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, 1, -1)]
    [InlineData(int.MinValue, int.MaxValue, -1)]
    public void Divide_CorrectResult(int operand1, int operand2, int expectedResult)
    {
        int computedResult = Calculator.Divide(operand1, operand2);
        Assert.Equal(expectedResult, computedResult);
    }

    [Fact]
    public void Divide_ByZero_Throws() => Assert.Throws<DivideByZeroException>(() => Calculator.Divide(1, 0));

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(-1, 1, -1)]
    [InlineData(0, 0, 0)]
    [InlineData(int.MinValue, int.MaxValue, int.MinValue)]
    public void Multiply_CorrectResult(int operand1, int operand2, int expectedResult)
    {
        int computedResult = Calculator.Multiply(operand1, operand2);
        Assert.Equal(expectedResult, computedResult);
    }
}
