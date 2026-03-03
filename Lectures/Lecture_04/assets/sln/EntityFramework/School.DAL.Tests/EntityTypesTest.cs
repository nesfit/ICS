using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Seeds;
using Xunit;

namespace School.DAL.Tests
{
    public sealed class EntityTypesTest : IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;
        private const string DbName = nameof(EntityStatesTest);

        public EntityTypesTest()
        {
            _schoolDbContextSut = TestDbContextFactory.CreateInMemory(databaseName: DbName);
        }
        
        [Fact]
        public void POCO_EntitiesTest()
        {
            var jane = _schoolDbContextSut.Students.Single(a => a.Id == Seed.StudentJane.Id);

            Assert.Null(jane.Address);
        }

        [Fact]
        public void POCO_EntitiesIncludeTest()
        {
            var jane = _schoolDbContextSut
                .Students
                .Include(s => s.Address)
                .Include(i=>i.ProjectGroup)
                .Include(i=>i.StudentCourses)
                .ThenInclude(i=>i.Course)
                .Single(s => s.Id == Seed.StudentJane.Id);

            Assert.Equivalent(ToComparableSnapshot(Seed.StudentJane), ToComparableSnapshot(jane));
        }

        [Fact]
        public void POCO_ProxyTest()
        {
            using var schoolDbContextSut = TestDbContextFactory.CreateInMemory(
                lazyLoading: true,
                databaseName: DbName);

            var jane = schoolDbContextSut.Students.Single(a => a.Id == Seed.StudentJane.Id);

            Assert.Equivalent(ToComparableSnapshot(Seed.StudentJane), ToComparableSnapshot(jane));
        }

        private static object ToComparableSnapshot(StudentEntity student)
            => new
            {
                student.Id,
                student.Name,
                student.ProjectGroupId,
                Address = student.Address is null
                    ? null
                    : new
                    {
                        student.Address.Id,
                        student.Address.Street,
                        student.Address.City,
                        student.Address.State,
                        student.Address.Country
                    },
                ProjectGroup = student.ProjectGroup is null
                    ? null
                    : new
                    {
                        student.ProjectGroup.Id,
                        student.ProjectGroup.MaxCapacity,
                        student.ProjectGroup.AvailableSpots
                    },
                StudentCourses = student.StudentCourses
                    .OrderBy(i => i.Id)
                    .Select(i => new
                    {
                        i.Id,
                        i.StudentId,
                        i.CourseId,
                        Course = i.Course is null
                            ? null
                            : new
                            {
                                i.Course.Id,
                                i.Course.Name,
                                i.Course.Description
                            }
                    })
                    .ToList()
            };

        public void Dispose() => _schoolDbContextSut?.Dispose();
    }
}
