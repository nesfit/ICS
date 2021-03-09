using System;
using System.IO;
using System.IO.Pipes;

namespace Examples
{
    public class PipeClientSample
    {
        static void Main(string[] args)
        {
            using (var pipeClient =
                new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
            {

                // Connect to the pipe or wait until the pipe is available.
                Console.Write("Attempting to connect to pipe...");
                pipeClient.Connect();

                Console.WriteLine("Connected to pipe.");
                Console.WriteLine("There are currently {0} pipe server instances open.",
                    pipeClient.NumberOfServerInstances);
                using (var streamReader = new StreamReader(pipeClient))
                {
                    // Display the read text to the console
                    string temp;
                    while ((temp = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine("Received from server: {0}", temp);
                    }
                }
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}