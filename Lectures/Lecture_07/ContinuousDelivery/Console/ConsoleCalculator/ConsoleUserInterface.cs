using System;
using Calculators.Engine;

namespace ConsoleCalculator
{
    internal class ConsoleUserInterface : IUserInterface
    {
        public MathematicModel ReadModel()
        {
            int first = ReadNumber("Insert first number:");
            int second = ReadNumber("Insert second number:");
            Operations operation = ReadOperation();

            return new MathematicModel()
            {
                First = first,
                Second = second,
                Operation = operation
            };
        }

        private static int ReadNumber(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        } 
        
        private static Operations ReadOperation()
        {
            Console.WriteLine("Insert operation name");
            Operations operation;
            Enum.TryParse(Console.ReadLine(), out operation);
            return operation;
        }

        public void WriteResult(int result)
        {
            string message = string.Format("Result is: {0}", result);
            Console.WriteLine(message);
            Console.WriteLine("Press any key to exit...");
            //Console.ReadKey(); // causes issues in the acceptance test, ignore for now
        }
    }
}