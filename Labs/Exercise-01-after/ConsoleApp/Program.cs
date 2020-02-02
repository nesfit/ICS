using System;

namespace Exercise_01.ConsoleApp
{
    internal class Program
    {
        /// <summary>
        ///     function Main - has to be static, has to have a name "Main", doesn't have to return a value
        ///     - cannot call non-static methods
        /// </summary>
        /// <param name="args">array of strings which represents parameters of the program</param>
        private static void Main(string[] args)
        {
            CodeDemonstrations.RunAllDemonstrations();

            // stop the program at the end
            WaitForPressedKey();
        }

        /// <summary>
        ///     Helper - waits for any key to be pressed on a keyboard
        ///     Holds the command prompt opened before program exits.
        /// </summary>
        private static void WaitForPressedKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}