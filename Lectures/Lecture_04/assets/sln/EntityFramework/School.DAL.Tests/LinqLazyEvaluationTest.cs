using System;
using System.Collections.Generic;
using System.Linq;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Seeds;
using Xunit;

namespace School.DAL.Tests
{
    public class LinqLazyEvaluationTest : IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;
        private readonly DbContextInMemoryFactory _dbContextFactory;

        public LinqLazyEvaluationTest()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(EntityStatesTest));
            _schoolDbContextSut = _dbContextFactory.Create();
            _schoolDbContextSut.Database.EnsureCreated();
        }

        [Fact]
        public void LazyEvaluationTest()
        {
            IEnumerable<StudentEntity> students;
            using (var schoolDbContextSut = _dbContextFactory.Create())
            {
                students = schoolDbContextSut.Students.Where(s => s.Id == Seed.StudentJane.Id);
            }

            //Materialized outside of using scope
            Assert.Throws<ObjectDisposedException>(() => students.ToList());
        }

        public void Dispose()
        {
            _schoolDbContextSut?.Dispose();
        }
    }
}