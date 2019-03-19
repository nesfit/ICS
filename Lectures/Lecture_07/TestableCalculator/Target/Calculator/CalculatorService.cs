using System;

namespace Calculator
{
    internal class CalculatorService
    {
        private readonly Mathematics mathematic;
        private readonly IUserInterface userInterface;

        public CalculatorService(Mathematics mathematic, IUserInterface userInterface)
        {
            // Constructor injection of services
            this.mathematic = mathematic;
            this.userInterface = userInterface;
        }

        public void Run()
        {
            int first = userInterface.ParseInput();
            int second = userInterface.ParseInput();
            var command = userInterface.ParseCommand();
            int result = Calculate(command, first, second);
            userInterface.WriteOutput(result);
        }

        private int Calculate(Commands command, int first, int second)
        {
            switch (command)
            {
                case Commands.add:
                    return mathematic.Add(first, second);
                case Commands.sub:
                    return mathematic.Substract(first, second);
                case Commands.mul:
                    return mathematic.Multiple(first, second);
                default:
                    throw new InvalidOperationException("Unknown command in calculator");
            }
        }
    }
}