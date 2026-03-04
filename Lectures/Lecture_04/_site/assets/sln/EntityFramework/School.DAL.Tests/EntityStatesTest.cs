using System;
using School.DAL;
using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using Xunit;

namespace School.DAL.Tests
{
    public sealed class EntityStatesTest: IDisposable
    {
        private readonly SchoolDbContext _schoolDbContextSut;

        public EntityStatesTest()
        {
            _schoolDbContextSut = TestDbContextFactory.CreateInMemory(databaseName: nameof(EntityStatesTest));
        }

        private readonly StudentEntity _studentEntity = new()
        {
            Name = "Jane"
        };

        [Fact]
        public void Add_SetsEntityStateToAdded()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            Assert.Equal(EntityState.Added, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void SaveChanges_TransitionsAddedEntityToUnchanged()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            Assert.Equal(EntityState.Unchanged, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void ChangingTrackedProperty_SetsEntityStateToModified()
        {
            var entityEntry = _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            entityEntry.Entity.Name = "John";
            Assert.Equal(EntityState.Modified, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void Remove_SetsEntityStateToDeleted()
        {
            _schoolDbContextSut.Students.Add(_studentEntity);
            _schoolDbContextSut.SaveChanges();
            _schoolDbContextSut.Remove(_studentEntity);
            Assert.Equal(EntityState.Deleted, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        [Fact]
        public void NewEntity_IsDetachedBeforeTracking()
        {
            Assert.Equal(EntityState.Detached, _schoolDbContextSut.Entry(_studentEntity).State);
        }

        public void Dispose() => _schoolDbContextSut?.Dispose();
    }
}
