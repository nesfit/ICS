using System;

namespace CleanCodeSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stuff();
        }

        // Calculating addition operation
        private static void Stuff()
        {
            // First number for addition
            int n1;
            // Second number for addition
            int n2;
            // Answer from the user
            int a;
            // Correct answer
            int r;

            // Asking user to input a number
            Console.Write("Zadejte 1. číslo pro sčítání: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out n1))
            {
            }

            // Asking user to input a number
            Console.Write("Zadejte 2. číslo pro sčítání: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out n2))
            {
            }

            Console.Write("Zadejte Vaši odpověď: ");

            // Reading number from console
            while (!int.TryParse(Console.ReadLine(), out a))
            {
            }

            // Correct answer
            r = n1 + n2;

            // Checking if the answer from the user was correct
            if (r == a)
            {
                // Setting color to green
                Console.ForegroundColor = ConsoleColor.Green;

                // Printing the result
                Console.Write("Vaše odpověď \"");
                Console.Write(a);
                Console.Write("\" byla správná");
            }
            else
            {
                // Setting color to red
                Console.ForegroundColor = ConsoleColor.Red;

                // Printing the result
                Console.Write("Vaše odpověď \"");
                Console.Write(a);
                Console.Write("\" byla nesprávná");
            }

            // Waiting for input from user
            Console.ReadKey();
        }
    }
}
