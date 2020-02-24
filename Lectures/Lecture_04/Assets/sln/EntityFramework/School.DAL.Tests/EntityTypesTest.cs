using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Seeds;
using Xunit;

namespace School.DAL.Tests
{
    public class EntityTypesTest : IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;
        private const string DbName = nameof(EntityStatesTest);

        public EntityTypesTest()
        {
            var dbContextFactory = new DbContextInMemoryFactory(DbName);
            _schoolDbContextSut = dbContextFactory.Create();
            _schoolDbContextSut.Database.EnsureCreated();
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
                .Include(i=>i.Grade)
                .Include(i=>i.StudentCourses)
                .ThenInclude(i=>i.Course)
                .Single(s => s.Id == Seed.StudentJane.Id);

            Assert.Equal(jane, Seed.StudentJane, StudentEntity.StudentEntityComparer);
        }

        [Fact]
        public void POCO_ProxyTest()
        {
            var lazyLoadingDbContextInMemoryFactory = new LazyLoadingDbContextInMemoryFactory(DbName);

            using var schoolDbContextSut = lazyLoadingDbContextInMemoryFactory.Create();
            schoolDbContextSut.Database.EnsureCreated();

            var jane = schoolDbContextSut.Students.Single(a => a.Id == Seed.StudentJane.Id);

            Assert.Equal(jane, Seed.StudentJane, StudentEntity.StudentEntityComparer);
        }

        public void Dispose()
        {
            _schoolDbContextSut?.Dispose();
        }
    }
}