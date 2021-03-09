using System;
using System.IO;

namespace Examples
{
    public class FileSample
    {
        public static void Main()
        {
            var file = File.ReadAllText("C:\\file.txt");

            Console.WriteLine(file);
            Console.WriteLine(file.Length);

            File.WriteAllText("C:\\file.txt", "Hello world!");
        }
    }
}