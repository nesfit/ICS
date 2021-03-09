using System;
using System.Collections;

namespace Examples
{
    public class QueueSample
    {
        public static void Main()
        {
            // Creates and initializes a new Queue.
            var queue = new Queue();
            queue.Enqueue("Hello");
            queue.Enqueue("World");
            queue.Enqueue("!");

            // Displays the properties and values of the Queue.
            Console.WriteLine("myQ");
            Console.WriteLine($"    Count:    {queue.Count}");

            Console.Write("    Values:");
            foreach (var obj in queue)
                Console.Write($"    {obj}");
            Console.WriteLine();
        }
    }
}