using System;
using System.IO;

namespace Examples
{
    public class DirectorySample
    {
        public static void Main()
        {
            var sourceDirectory = @"C:\source";
            var destinationDirectory = @"C:\destination";

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}