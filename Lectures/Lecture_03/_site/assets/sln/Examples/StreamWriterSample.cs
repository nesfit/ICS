using System;
using System.IO;

namespace Examples
{
    public class StreamWriterSample
    {
        public static void Main()
        {
            try
            {
                // Create an instance of StreamWriter to write to a file.
                // The using statement also closes the StreamWriter.
                using (var streamWriter = new StreamWriter("TestFile.txt"))
                {
                    // Loop through ten numbers.
                    for (var i = 0; i < 10; i++)
                    {
                        // Write format string to file.
                        streamWriter.WriteLine("i");
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Could not write to the file:");
                Console.WriteLine(e.Message);
            }
        }
    }
}