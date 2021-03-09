using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqProjectionOperatorsTest
    {
        [Fact]
        public void SelectTest()
        {
            var numbers = new List<string>{"ONE", "TWO", "THREE", "FOUR", "FIVE"};

            var result = numbers.Select(n => n.ToLower()).ToList();

            Assert.Contains("one", result);
            Assert.Contains("two", result);
            Assert.Contains("three", result);

            Assert.DoesNotContain("ONE", result);
            Assert.DoesNotContain("TWO", result);
            Assert.DoesNotContain("THREE", result);
        }

        [Fact]
        public void SelectMany()
        {
            string[] fruits = { "Grape", "Orange", "Apple" };
            int[] amounts = { 1, 2, 3 };

            var crossJoin = fruits.SelectMany(f => amounts, (f, a) => new
            {
                Fruit = f,
                Amount = a
            });

            foreach (var fruit in fruits)
            {
                foreach (var amount in amounts)
                {
                    Assert.True(crossJoin.Count(r => r.Amount == amount && r.Fruit == fruit) == 1);
                }
            }
        }
    }
}