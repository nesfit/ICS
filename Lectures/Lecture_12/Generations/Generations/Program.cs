using System;
using System.Diagnostics;
using System.Text;

namespace Generations
{
    internal class Program
    {
        private static void Main()
        {
            string hello = "Hello word!";
            DebuggerBreak();
            Console.WriteLine("Nejvyšší generace je: {0}", GC.MaxGeneration);

            MemoryInfo(hello);
            Console.ReadLine();
            
            MakeGarbage();
            MemoryInfo(hello);
            Console.ReadLine();

            GC.Collect();
            MemoryInfo(hello);
            Console.ReadLine();

            GC.Collect(2);
            MemoryInfo(hello);
            Console.ReadLine();
        }

        private static void MemoryInfo<T>(T item)
        {
            Console.WriteLine("Generation: {0}", GC.GetGeneration(item));
            long totalMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"Total Memory: {totalMemory / 1024.0:n2}KB");
            Console.WriteLine();
            DebuggerBreak();
        }

        private static void MakeGarbage()
        {
            //GC.Collect();
            for (int i = 0; i < 1_000_000; i++)
            {
                var newStringBuilder = new StringBuilder();
                newStringBuilder.Append("Some text");
            }
        }

        private static void DebuggerBreak()
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }
    }
}