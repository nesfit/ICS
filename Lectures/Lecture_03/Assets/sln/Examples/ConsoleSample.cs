using System;

namespace Examples
{
    public class ConsoleSample
    {
        public static void Main()
        {
            Console.Clear();
            
            while (true)
            {
                Console.Write("Press any key, or 'X' to quit, or ");

                var consoleKeyInfo = Console.ReadKey(true);
                Console.WriteLine("  Key pressed: {0}\n", consoleKeyInfo.Key);

                if (consoleKeyInfo.Key == ConsoleKey.X) break;
            }
        }
    }
}