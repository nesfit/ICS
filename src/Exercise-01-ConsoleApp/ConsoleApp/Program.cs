using System;

namespace Exercise_01.ConsoleApp
{
    internal static class Program
    {
        /// <summary>
        ///     Method Main - has to be static, has to have a name "Main", doesn't have to return a value.
        /// </summary>
        /// <param name="args">Array of strings which represents parameters of the program.</param>
        private static void Main(string[] args)
        {
            CodeDemonstrations.RunAllDemonstrations();

            // stop the program at the end
            WaitForPressedKey();
        }

        /// <summary>
        ///     Helper - waits for any key to be pressed on a keyboard.
        ///     Holds the command prompt open before program exits.
        /// </summary>
        private static void WaitForPressedKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
