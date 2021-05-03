using PortableLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            int number1 = 13;
            int number2 = 29;

            Console.WriteLine($"Using calculator from PCL: {number1} + {number2} = {calc.Add(number1, number2)}");

            Console.WriteLine("Press any key to exit progam");
            Console.ReadKey();
        }
    }
}
