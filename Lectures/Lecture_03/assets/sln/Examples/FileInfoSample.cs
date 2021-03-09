using System;
using System.IO;

namespace Examples
{
    public class FileInfoSample
    {
        public static void Main()
        {
            var info = new FileInfo("C:\\file.txt");

            var time = info.CreationTime;
            Console.WriteLine(time);

            time = info.LastAccessTime;
            Console.WriteLine(time);

            time = info.LastWriteTime;
            Console.WriteLine(time);
        }
    }
}