using System;
using System.IO;

namespace Examples
{
    public class DirectoryInfoSample
    {
        public static void Main()
        {
            // Specify the directories you want to manipulate.
            var directoryInfo = new DirectoryInfo(@"c:\MyDir");
            try
            {
                // Determine whether the directory exists.
                if (directoryInfo.Exists)
                {
                    // Indicate that the directory already exists.
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                directoryInfo.Create();
                Console.WriteLine("The directory was created successfully.");

                // Delete the directory.
                directoryInfo.Delete();
                Console.WriteLine("The directory was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }
        }
    }
}