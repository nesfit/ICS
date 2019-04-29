using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PassingParameters
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        private static void DisplayList<T>(IEnumerable<T> list)
        {
            foreach (T b in list)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();
        }

        private static void SomeMagicAndAddValueToListByValue(List<byte> list, byte value)
        {
            Console.WriteLine("Break in method");
            Debugger.Break();
            list = Helper.SomeMagicMethod(list);
            Console.WriteLine("Break after magic");
            Debugger.Break();
            list.Add(value);
        }

        private static void SomeMagicAndAddValueToListByReference(ref List<byte> list, byte value)
        {
            Console.WriteLine("Break in method");
            Debugger.Break();
            list = Helper.SomeMagicMethod(list);
            Console.WriteLine("Break after magic");
            Debugger.Break();
            list.Add(value);
        }
    }
}