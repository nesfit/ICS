using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Linq.Gotchas
{
    public class LinqComparerPitfallsTest
    {
        [Fact]
        public void Distinct_OnCustomType_WithoutComparerUsesReferenceEquality()
        {
            var students = new[]
            {
                new Student("A@fit.vutbr.cz"),
                new Student("a@fit.vutbr.cz")
            };

            var distinctWithoutComparer = students.Distinct().ToList();
            var distinctWithComparer = students.Distinct(new StudentEmailComparer()).ToList();

            Assert.Equal(2, distinctWithoutComparer.Count);
            Assert.Single(distinctWithComparer);
        }

        [Fact]
        public void Distinct_CanUseCaseInsensitiveStringComparer()
        {
            var tags = new[] { "linq", "LINQ", "Linq" };
            var distinct = tags.Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            Assert.Single(distinct);
        }

        private sealed class Student
        {
            public Student(string email)
            {
                Email = email;
            }

            public string Email { get; }
        }

        private sealed class StudentEmailComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (x is null || y is null)
                {
                    return false;
                }

                return StringComparer.OrdinalIgnoreCase.Equals(x.Email, y.Email);
            }

            public int GetHashCode(Student obj)
            {
                return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Email);
            }
        }
    }
}
