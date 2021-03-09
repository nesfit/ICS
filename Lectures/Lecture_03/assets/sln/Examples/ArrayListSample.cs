using System;
using System.Collections;

namespace Examples
{
    public class ArrayListSample
    {
        public static void Main()
        {
            // Creates and initializes a new ArrayList.
            var arrayList = new ArrayList();
            arrayList.Add("Hello");
            arrayList.Add("World");
            arrayList.Add("!");

            // Displays the properties and values of the ArrayList.
            Console.WriteLine("arrayList");
            Console.WriteLine($"    Count:    {arrayList.Count}");
            Console.WriteLine($"    Capacity: {arrayList.Capacity}");

            Console.Write("    Values:");
            foreach (var obj in arrayList)
                Console.Write($"   {obj}");
            Console.WriteLine();
        }
    }
}