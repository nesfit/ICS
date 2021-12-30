using System;

namespace Exercise_01.CalculatorUtils
{
    public class Calculator
    {
        /// <summary>
        ///     Calculates basic mathematical operations (+,-,*,/)
        /// </summary>
        public static int Calculate(int operand1, int operand2, MathOperation mathOperation) =>
            mathOperation switch
            {
                MathOperation.Addition => Add(operand1, operand2),
                MathOperation.Subtraction => Subtract(operand1, operand2),
                MathOperation.Multiplication => Multiply(operand1, operand2),
                MathOperation.Division => Divide(operand1, operand2),
                _ => throw new ArgumentOutOfRangeException(nameof(mathOperation), mathOperation, null)
            };

        public static int Add(int operand1, int operand2) => operand1 + operand2;

        public static int Divide(int operand1, int operand2) => operand1 / operand2;

        public static int Multiply(int operand1, int operand2) => operand1 * operand2;

        public static int Subtract(int operand1, int operand2) => operand1 - operand2;
    }
}