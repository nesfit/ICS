﻿using System.Diagnostics.CodeAnalysis;
using Examples;
using Xunit;

namespace Lecture02.Tests
{
    public class IsOperator
    {
        [Fact]
        public void IsOperatorTest()
        {
            WildCat unknownCat = new WildCat();

            Assert.False(unknownCat is Cat);
        }
    }
}