using System;                                            // Importing namespace

namespace Tests                                          // Namespace declaration
{
    public class HelloWorld                              // Class declaration
    {
        private static void Main(string[] args)          // Method declaration
        {
            Console.WriteLine("Hello World!");           // Statement 1

            Console.WriteLine("Press any key to exit."); // Statement 2
            Console.ReadKey();                           // Statement 3
        }
    }
}