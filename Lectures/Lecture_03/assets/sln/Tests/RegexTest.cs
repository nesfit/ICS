using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Tests
{
    public class RegexTest
    {
        [Fact]
        public void Test()
        {
            // Define a regular expression for repeated words.
            var regex = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.        
            var text = "The the quick brown fox  fox jumps over the lazy dog dog.";

            // Find matches.
            var matches = regex.Matches(text);

            // Count and get matches
            Assert.Equal(3, matches.Count);
            Assert.Equal("The", matches[0].Groups["word"].Value);
            Assert.Equal("fox", matches[1].Groups["word"].Value);
            Assert.Equal("dog", matches[2].Groups["word"].Value);
        }
    }
}