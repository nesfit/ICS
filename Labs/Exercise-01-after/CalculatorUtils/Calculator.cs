using System;

namespace Exercise_01.CalculatorUtils
{
    public class Calculator
    {
        /// <summary>
        ///     Calculates basic mathematical operations (+,-,*,/)
        /// </summary>
        public static Int32 Calculate(Int32 operand1, Int32 operand2, MathOperation mathOperation)
        {
            switch (mathOperation)
            {
                case MathOperation.Addition:
                    return Add(operand1, operand2);
                case MathOperation.Subtraction:
                    return Substract(operand1, operand2);
                case MathOperation.Multiplication:
                    return Multiply(operand1, operand2);
                case MathOperation.Division:
                    return Divide(operand1, operand2);
                default:
                    throw new ArgumentOutOfRangeException(nameof(mathOperation), mathOperation, null);
            }
        }

        private static Int32 Add(Int32 operand1, Int32 operand2)
        {
            return operand1 + operand2;
        }

        private static Int32 Divide(Int32 operand1, Int32 operand2)
        {
            return operand1 / operand2;
        }

        private static Int32 Multiply(Int32 operand1, Int32 operand2)
        {
            return operand1 * operand2;
        }

        private static Int32 Substract(Int32 operand1, Int32 operand2)
        {
            return operand1 - operand2;
        }
    }
}