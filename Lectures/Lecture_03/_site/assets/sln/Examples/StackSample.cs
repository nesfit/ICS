using System;
using System.Collections;

namespace Examples
{
    public class StackSample
    {
        public static void Main()
        {
            // Creates and initializes a new Stack.
            var stack = new Stack();
            stack.Push("Hello");
            stack.Push("World");
            stack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("stack");
            Console.WriteLine($"    Count:    {stack.Count}");

            Console.Write("    Values:");
            foreach (var obj in stack)
                Console.Write($"    {obj}");
            Console.WriteLine();
        }
    }
}
