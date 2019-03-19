using Calculators.Engine;

namespace ConsoleCalculator
{
    internal class Program
    {
        private static void Main()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            var calculator = new CalculatorService(userInterface);
            calculator.Run();
        }
    }
}
