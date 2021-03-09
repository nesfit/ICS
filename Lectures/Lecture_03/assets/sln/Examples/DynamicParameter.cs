using System;

namespace Examples
{
    public class DynamicParameter
    {
        static void PrintValue(dynamic val)
        {
            Console.WriteLine(val);
        }

        static void Main(string[] args)
        {
            PrintValue("Hello World!!");
            PrintValue(100);
            PrintValue(100.50);
            PrintValue(true);
            PrintValue(DateTime.Now);
        }

        // Output:
        // Hello World!! 
        // 100 
        // 100.50 
        // True 
        // 01-01-2014 10:10:50
    }
}