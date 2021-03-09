using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GenericListTest
    {
        [Fact]
        public void Test1()
        {
            var numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(7);

            Assert.Equal(4, numbers.Count);
        }

        [Fact]
        public void Test2()
        {
            var list = new List<bool> {true, false, true};
            list.Clear();

            Assert.Empty(list);
        }

        [Fact]
        public void Test3()
        {
            var numbers = new List<int> {2, 3, 5, 7};

            Assert.Contains(2, numbers);
            Assert.DoesNotContain(8, numbers);
        }

        [Fact]
        public void Test4()
        {
            var numbers = new List<int> { 2, 3, 5, 7 };

            Assert.True(numbers.TrueForAll(element => element < 20));
        }

        [Fact]
        public void Test5()
        {
            var numbers = new List<int> { 2, 3, 5, 7 };
            var numbers2 = new List<int> {20, 30, 50, 70};
            numbers.AddRange(numbers2);

            Assert.Equal(8, numbers.Count);
        }
    }
}