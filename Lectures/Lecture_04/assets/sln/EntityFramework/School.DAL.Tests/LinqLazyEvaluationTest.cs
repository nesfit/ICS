using System;
using System.Collections.Generic;
using System.Linq;
using School.DAL.Entities;
using School.DAL.Seeds;
using Xunit;

namespace School.DAL.Tests
{
    public class LinqLazyEvaluationTest : IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;
        private readonly string _databaseName;

        public LinqLazyEvaluationTest()
        {
            _databaseName = nameof(EntityStatesTest);
            _schoolDbContextSut = TestDbContextFactory.CreateInMemory(databaseName: _databaseName);
        }

        [Fact]
        public void LazyEvaluationTest()
        {
            IEnumerable<StudentEntity> students;
            using (var schoolDbContextSut = TestDbContextFactory.CreateInMemory(databaseName: _databaseName))
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
