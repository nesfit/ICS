using System.Linq;
using Xunit;

namespace Tests.Linq.Gotchas
{
    public class LinqJoinAdvancedTest
    {
        [Fact]
        public void GroupJoinWithDefaultIfEmpty_ImplementsLeftJoin()
        {
            var languages = new[]
            {
                new Language(1, "English"),
                new Language(2, "Spanish"),
                new Language(3, "German")
            };

            var persons = new[]
            {
                new Person("Tom", 1),
                new Person("Ana", 2)
            };

            var leftJoin =
                from language in languages
                join person in persons on language.Id equals person.LanguageId into grouped
                from person in grouped.DefaultIfEmpty()
                select new
                {
                    Language = language.Name,
                    Person = person?.FirstName
                };

            Assert.Equal(3, leftJoin.Count());
            Assert.Null(leftJoin.Single(x => x.Language == "German").Person);
            Assert.Equal("Tom", leftJoin.Single(x => x.Language == "English").Person);
        }

        private sealed record Language(int Id, string Name);
        private sealed record Person(string FirstName, int LanguageId);
    }
}
