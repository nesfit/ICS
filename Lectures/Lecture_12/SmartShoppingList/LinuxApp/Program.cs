using System;
using BL;

namespace LinuxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bl = new BusinessLogic();
            bl.DoWork();

            Console.WriteLine("Hello World!");

            Console.WriteLine("Press any key to exit program");
            Console.ReadKey();
        }
    }
}
