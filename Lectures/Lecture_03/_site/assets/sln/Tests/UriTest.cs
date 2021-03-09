using System;
using Xunit;

namespace Tests
{
    public class UriTest
    {
        [Fact]
        public void Test()
        {
            var uri1 = new Uri("https://www.microsoft.com");
            var uri2 = new Uri("https://www.microsoft.com/en-us");

            Assert.True(uri1.IsBaseOf(uri2));
        }
    }
}