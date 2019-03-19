using System;

namespace Calculator
{
    /// <summary>
    /// Console implementation of calculator user interface interaction
    /// </summary>
    internal class UserInterface : IUserInterface
    {
        public void WriteOutput(int result)
        {
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public int ParseInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public Commands ParseCommand()
        {
            return (Commands)Enum.Parse(typeof(Commands), Console.ReadLine());
        }
    }
}