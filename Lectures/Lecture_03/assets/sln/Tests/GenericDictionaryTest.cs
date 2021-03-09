using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GenericDictionaryTest
    {
        [Fact]
        public void Test()
        {
            var dict = new Dictionary<int, string>()
            {
                {1,"One"},
                {2, "Two"},
                {3,"Three"}
            };

            Assert.True(dict.ContainsKey(1));
            Assert.False(dict.ContainsKey(4));
        }
    }
}