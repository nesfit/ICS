using System;
using System.Collections;
using Xunit;

namespace Tests
{
    public class HashtableTest
    {
        [Fact]
        public void Test()
        {
            // Create a new hash table.
            var hashtable = new Hashtable();

            // Add some elements to the hash table. There are no 
            // duplicate keys, but some of the values are duplicates.
            hashtable.Add("txt", "notepad.exe");
            hashtable.Add("bmp", "paint.exe");
            hashtable.Add("dib", "paint.exe");
            hashtable.Add("rtf", "wordpad.exe");

            Assert.Throws<ArgumentException>(() => hashtable.Add("txt", "winword.exe"));
            Assert.Equal("notepad.exe", hashtable["txt"]);
        }
    }
}