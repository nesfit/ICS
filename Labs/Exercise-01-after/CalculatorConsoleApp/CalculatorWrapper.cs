using System;
using Exercise_01.CalculatorUtils;

namespace Exercise_01.CalculatorConsoleApp
{
    internal class CalculatorWrapper
    {
        internal static void Calculate(CommandLineOptions options)
        {
            var op1 = CheckOperand(options.First);
            var op2 = CheckOperand(options.Second);
            var operation = CheckOperation(options.Operation);
            ExecuteOperation(op1, op2, operation);
        }

        private static Int32 CheckOperand(Int32? operand)
        {
            if (operand == null)
                throw new ArgumentNullException(nameof(operand), "Operand cannot be null!");
            return operand.Value;
        }

        private static MathOperation CheckOperation(MathOperation? operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation), "Operation cannot be null!");
            return operation.Value;
        }

        private static void ExecuteOperation(Int32 op1, Int32 op2, MathOperation operation)
        {
            try
            {
                var result = Calculator.Calculate(op1, op2, operation);
                PublishResult(op1, op2, operation, result);
            }
            catch (Exception ex)
            {
                Program.LogException(ex);
            }
        }

        private static void PublishResult(Int32 op1, Int32 op2, MathOperation operation, Int32 result)
        {
            Console.WriteLine($"{op1}{operation.GetDescription()}{op2}={result}");
        }
    }
}