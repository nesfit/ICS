using System.Text;
using Xunit;

namespace Tests
{
    public class StringBuilderTest
    {
        [Fact]
        public void Test()
        {
            // Create a StringBuilder that expects to hold 50 characters.
            // Initialize the StringBuilder with "ABC".
            var sb = new StringBuilder("ABC", 50);

            // Append three characters (D, E, and F) to the end of the StringBuilder.
            sb.Append(new[] { 'D', 'E', 'F' });

            // Append a format string to the end of the StringBuilder.
            sb.AppendFormat($"GHI{'J'}{'k'}");

            // Insert a string at the beginning of the StringBuilder.
            sb.Insert(0, "Alphabet: ");

            // Replace all lowercase k's with uppercase K's.
            sb.Replace('k', 'K');

            Assert.Equal("21 chars: Alphabet: ABCDEFGHIJK", $"{sb.Length} chars: {sb}");
        }
    }
}