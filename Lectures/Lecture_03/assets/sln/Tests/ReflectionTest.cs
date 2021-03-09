using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Tests
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { private get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    public class RefrectionTest
    {
        [Fact]
        public void Test1()
        {
            var type = typeof(Person);

            Assert.Equal("Person", type.Name);
            Assert.Equal("Tests", type.Namespace);
        }

        [Fact]
        public void Test2()
        {
            var type = typeof(Person);
            var propertyInfos = type.GetProperties();
            var propertyNames = propertyInfos.Select(p => p.Name).ToList();

            Assert.Equal(4, propertyInfos.Length);
            Assert.Contains("Id", propertyNames);
            Assert.Contains("FirstName", propertyNames);
            Assert.DoesNotContain("RandomString", propertyNames);
        }

        [Fact]
        public void Test3()
        {
            var person = new Person {FirstName = "Mike"};
            var property = typeof(Person).GetProperty("FirstName");
            var value = property?.GetValue(person, null);

            Assert.Equal("Mike", value);
        }
    }
}