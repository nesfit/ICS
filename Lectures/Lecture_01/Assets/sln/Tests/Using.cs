using System;
using System.IO;

namespace Tests
{
    public class Using
    {
        public void Example()
        {
            using (var streamReader = new StreamReader("c:\\file.txt"))
            {
                Console.Write(streamReader.ReadToEnd());
            }
        }
    }
}