﻿using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class IsOperator
    {
        [Fact]
        public void IsOperatorTest()
        {
            var unknownCat = new UnknownCat();
            Assert.False(unknownCat is Cat);
        }
    }
}