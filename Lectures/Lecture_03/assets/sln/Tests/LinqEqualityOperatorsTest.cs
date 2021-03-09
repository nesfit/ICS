using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqEqualityOperatorsTest
    {
        [Fact]
        public void ContatTest()
        {
            string[] words = { "one", "two", "three" };
            string[] wordsSame = { "one", "two", "three" };
            string[] wordsOrder = { "two", "three", "one" };
            string[] wordsCase = { "one", "TWO", "three" };

            var resultSame = words.SequenceEqual(wordsSame);
            var resultOrder = words.SequenceEqual(wordsOrder);
            var resultCase = words.SequenceEqual(wordsCase);
            var resultCaseIgnored = words.SequenceEqual(wordsCase, StringComparer.OrdinalIgnoreCase);

            Assert.True(resultSame);
            Assert.False(resultOrder);
            Assert.False(resultCase);
            Assert.True(resultCaseIgnored);
        }
    }
}