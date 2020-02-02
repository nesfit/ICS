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

        private static int CheckOperand(int? operand)
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

        private static void ExecuteOperation(int op1, int op2, MathOperation operation)
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

        private static void PublishResult(int op1, int op2, MathOperation operation, int result)
        {
            Console.WriteLine($"{op1}{operation.GetDescription()}{op2}={result}");
        }
    }
}