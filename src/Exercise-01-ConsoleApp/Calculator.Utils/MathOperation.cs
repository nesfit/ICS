using System.ComponentModel;

namespace Calculator.Utils;

public enum MathOperation
{
    [Description("+")] Addition,
    [Description("-")] Subtraction,
    [Description("*")] Multiplication,
    [Description("/")] Division
}
