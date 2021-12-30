using System;
using System.Threading;

namespace DockerMain
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = 20;
            int start = 1;

            if (args.Length == 1 && int.TryParse(args[0], out int startArg) && startArg < end)
            {
                start = startArg;
            }

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine($"Count: {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
