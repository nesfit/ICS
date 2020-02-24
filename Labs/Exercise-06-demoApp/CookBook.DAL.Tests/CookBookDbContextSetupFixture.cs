using System;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextSetupFixture : IDisposable
    {
        public InMemoryDbContextFactory DbContextFactory { get; }

        public CookBookDbContextSetupFixture(string testDbName) => DbContextFactory = new InMemoryDbContextFactory(testDbName);

        public void PrepareDatabase()
        {
            using var dbx = DbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();
        }

        public void TearDownDatabase()
        {
            using var dbx = DbContextFactory.CreateDbContext();
            dbx.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            TearDownDatabase();
        }
    }
}