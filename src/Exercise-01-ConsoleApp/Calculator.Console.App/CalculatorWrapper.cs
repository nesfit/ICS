using System;
using Calculator.Utils;

namespace Calculator.App;

internal static class CalculatorWrapper
{
    internal static void Calculate(CommandLineOptions options)
    {
        int op1 = CheckOperand(options.First);
        int op2 = CheckOperand(options.Second);
        MathOperation operation = CheckOperation(options.Operation);

        int? result = ExecuteOperation(op1, op2, operation);

        if (result is not null)
        {
            PublishResult(op1, op2, operation, result.Value);
        }
    }

    private static int CheckOperand(int? operand)
    {
        if (operand is null)
        {
            throw new ArgumentNullException(nameof(operand), "Operand cannot be null!");
        }

        return operand.Value;
    }

    private static MathOperation CheckOperation(MathOperation? operation)
    {
        if (operation is null)
        {
            throw new ArgumentNullException(nameof(operation), "Operation cannot be null!");
        }

        return operation.Value;
    }

    private static int? ExecuteOperation(int op1, int op2, MathOperation operation)
    {
        try
        {
            return Utils.Calculator.Calculate(op1, op2, operation);
        }
        catch (Exception ex)
        {
            Program.LogException(ex);
            return null;
        }
    }

    private static void PublishResult(int op1, int op2, MathOperation operation, int result)
        => Console.WriteLine($"{op1}{operation.GetDescription()}{op2}={result}");
}
