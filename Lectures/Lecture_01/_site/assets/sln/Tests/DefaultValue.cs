using System;
using Tests;
using Xunit;
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable CS0649 // Field 'DefaultValue._y' is never assigned to, and will always have its default value 0	Tests	C:\Users\pluskal\source\repos\ICS\Lectures\Lecture_01\assets\sln\Tests\DefaultValue.cs  11  Active
#pragma warning disable IDE0044 // Add readonly modifier

namespace Tests
{
    public class DefaultValue
    {
        int _y;
        [Fact]
        public void Test()
        {
            int x;
            //Console.WriteLine(x);        // Compile-time error

            int[] ints = new int[2];
            Assert.Equal(0, ints[0]);

            Assert.Equal(0, _y);
        }
    }
}
