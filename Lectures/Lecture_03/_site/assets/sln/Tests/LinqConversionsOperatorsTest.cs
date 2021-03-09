using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqConversionsOperatorsTest
    {
        [Fact]
        public void AsEnumerableTest()
        {
            string[] names = { "John", "Suzy", "Dave" };

            var result = names.AsEnumerable();

            Assert.True(result is IEnumerable<string>);
        }

        [Fact]
        public void AsQueryableTest()
        {
            string[] names = { "John", "Suzy", "Dave" };

            var result = names.AsQueryable();

            Assert.True(result is IQueryable<string>);
        }

        [Fact]
        public void CastTest()
        {
            var arrayList = new ArrayList {"India", "USA", "UK", "Australia"};

            IEnumerable<string> results = arrayList.Cast<string>();

            foreach (var result in results)
                Assert.True(result is string);
        }

        [Fact]
        public void OfTypeTest()
        {
            var arrayList = new ArrayList { "India", "USA", "UK", "Australia", 42, null, 5.02 };

            IEnumerable<string> results = arrayList.OfType<string>();

            Assert.True(4 == results.Count());
        }

        [Fact]
        public void ToArrayTest()
        {
            var numbers = new List<int>{ 1, 2, 3, 4 };

            var result = numbers.ToArray();

            Assert.True(result is int[]);
        }

        [Fact]
        public void ToDictionaryTest()
        {
            var list = new List<string>()
            {
                "cat",
                "dog",
                "animal"
            };

            var animals = list.ToDictionary(x => x, x => x == "dog");

            Assert.True(animals["dog"]);
            Assert.False(animals["cat"]);
        }

        [Fact]
        public void ToListTest()
        {
            string[] names = { "Brenda", "Carl", "Finn" };

            var result = names.ToList();

            Assert.True(result is List<string>);
        }
    }
}