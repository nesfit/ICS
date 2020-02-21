using System;
using School.DAL;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using School.DAL.Factories;
using Xunit;

namespace School.DAL.Tests
{
    public class EntityStatesTest: IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;

        public EntityStatesTest()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(EntityStatesTest));
            _schoolDbContextSut = dbContextFactory.Create();
            _schoolDbContextSut.Database.EnsureCreated();
        }

        readonly StudentEntity _studentEntity = new StudentEntity
        {
            Name = "Jane"
        };

        [Fact]
        public void AddedStateTest()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            Assert.Equal(EntityState.Added, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void UnchangedStateTest()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            Assert.Equal(EntityState.Unchanged, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void ModifiedStateTest()
        {
            var entityEntry = _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            entityEntry.Entity.Name = "John";
            Assert.Equal(EntityState.Modified, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void DeletedStateTest()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            _schoolDbContextSut.Remove(_studentEntity);
            Assert.Equal(EntityState.Deleted, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void DetachedStateTest()
        {
            Assert.Equal(EntityState.Detached, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        public void Dispose()
        {
            _schoolDbContextSut?.Dispose();
        }
    }
}