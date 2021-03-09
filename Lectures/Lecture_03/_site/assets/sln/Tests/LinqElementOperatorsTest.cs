using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqElementOperatorsTest
    {
        [Fact]
        public void ElementAtTest()
        {
            string[] words = { "One", "Two", "Three" };

            var result = words.ElementAt(1);

            Assert.Equal("Two", result);
        }

        [Fact]
        public void ElementAtOrDefaultTest()
        {
            string[] colors = { "Red", "Green", "Blue" };

            var resultIndex1 = colors.ElementAtOrDefault(1);
            var resultIndex10 = colors.ElementAtOrDefault(10);

            Assert.Equal("Green", resultIndex1);
            Assert.Null(resultIndex10);
        }

        [Fact]
        public void FirstTest()
        {
            string[] fruits = { "Banana", "Apple", "Orange" };

            Assert.Equal("Banana", fruits.First());
        }

        [Fact]
        public void FirstOrDefaultTest()
        {
            string[] countries = { "Denmark", "Sweden", "Norway" };
            string[] empty = { };

            Assert.Equal("Denmark", countries.FirstOrDefault());
            Assert.Null(empty.FirstOrDefault());
        }

        [Fact]
        public void Last()
        {
            int[] numbers = { 7, 3, 5 };

            Assert.Equal(5, numbers.Last());
        }

        [Fact]
        public void LastOrDefault()
        {
            string[] words = { "one", "two", "three" };
            string[] empty = { };

            Assert.Equal("three", words.LastOrDefault());
            Assert.Null(empty.LastOrDefault());
        }

        [Fact]
        public void Single()
        {
            string[] names1 = { "Peter" };
            string[] names2 = { "Peter", "Joe", "Wilma" };
            string[] empty = { };

            Assert.Equal("Peter", names1.Single());
            Assert.Throws<InvalidOperationException> (() => names2.Single());
            Assert.Throws<InvalidOperationException>(() => empty.Single());
        }

        [Fact]
        public void SingleOrDefault()
        {
            string[] names1 = { "Peter" };
            string[] names2 = { "Peter", "Joe", "Wilma" };
            string[] empty = { };

            Assert.Equal("Peter", names1.SingleOrDefault());
            Assert.Throws<InvalidOperationException>(() => names2.SingleOrDefault());
            Assert.Null(empty.SingleOrDefault());
        }
    }
}