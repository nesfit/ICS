using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class LinqJoinOperatorsTest
    {
        [Fact]
        public void JoinTest()
        {
            var strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four"
            };

            var strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };

            var innerJoin = strList1.Join(strList2,
                str1 => str1,
                str2 => str2,
                (str1, str2) => str1);

            Assert.Contains("One", innerJoin);
            Assert.Contains("Two", innerJoin);
        }

        class Language
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Person
        {
            public int LanguageId { get; set; }
            public string FirstName { get; set; }
        }

        [Fact]
        public void GroupJoinTest()
        {
            var english = new Language {Id = 1, Name = "English"};
            var russian = new Language {Id = 2, Name = "Russian"};
            
            var tom = new Person {LanguageId = 1, FirstName = "Tom"};
            var sandy = new Person {LanguageId = 1, FirstName = "Sandy"};
            var vladimir = new Person {LanguageId = 2, FirstName = "Vladimir"};
            var mikhail = new Person {LanguageId = 2, FirstName = "Mikhail"};

            var persons = new[] { tom, sandy, vladimir, mikhail };
            var languages = new[] { english, russian };

            var result = languages.GroupJoin(persons, l => l.Id, p => p.LanguageId,
                (l, p) => new { Key = l.Name, Persons = p });

            Assert.Contains(tom, result.First(l => l.Key == english.Name).Persons);
            Assert.Contains(sandy, result.First(l => l.Key == english.Name).Persons);
            Assert.Contains(vladimir, result.First(l => l.Key == russian.Name).Persons);
            Assert.Contains(mikhail, result.First(l => l.Key == russian.Name).Persons);
        }
    }
}