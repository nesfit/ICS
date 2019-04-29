using System;

namespace LargeObject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ulong kb = 1024;
            ulong mb = 1024 * kb;
            ulong gb = 1024 * mb;
            ulong gb4 = 2 * gb;

            var array = new int[gb4];
        }
    }
}