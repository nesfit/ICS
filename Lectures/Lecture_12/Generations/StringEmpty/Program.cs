using System;
using System.Collections.Generic;

namespace StringEmpty
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var emptyStrings = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                emptyStrings.Add("");
            }

            Console.ReadLine();

            var stringEmty = new List<string>();
            for (int l = 0; l < 1000; l++)
            {
                stringEmty.Add(string.Empty);
            }
            Console.ReadLine();
        }
    }
}