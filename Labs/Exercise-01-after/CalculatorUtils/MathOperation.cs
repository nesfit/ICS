using System.ComponentModel;

namespace Exercise_01.CalculatorUtils
{
    public enum MathOperation
    {
        [Description("+")] Addition,
        [Description("-")] Subtraction,
        [Description("*")] Multiplication,
        [Description("/")] Division
    }
}