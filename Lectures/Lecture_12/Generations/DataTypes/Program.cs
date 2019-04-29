using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataTypes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //PassingParameters*****************************************************
            Debugger.Break();
            byte value = 127;

            var list = new List<byte>();
            list.Add(125);
            list.Add(126);

            for (int i = 0; i < value; i++)
            {
                var instance = new MyClass();
                instance.Byte = (byte) i;
            }

            Console.WriteLine("Break after initialization");
            Debugger.Break();

            SomeMagicAndAddValueToListByValue(list, value);

            DisplayList(list);

            Console.WriteLine("Break after value method");
            Debugger.Break();

            SomeMagicAndAddValueToListByReference(ref list, value);

            DisplayList(list);

            Console.WriteLine("Break after reference method");
            Debugger.Break();

            Console.ReadLine();
            //PassingParameters*****************************************************
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
            list = list.SomeMagicMethod();
            list.Add(value);
            Console.WriteLine("Break after magic");
            Debugger.Break();
        }

        private static void SomeMagicAndAddValueToListByReference(ref List<byte> list, byte value)
        {
            Console.WriteLine("Break in method");
            Debugger.Break();
            list = list.SomeMagicMethod();
            list.Add(value);
            Console.WriteLine("Break after magic");
            Debugger.Break();
        }
    }

    class MyClass
    {
        public byte Byte { get; set; } 
    }
}