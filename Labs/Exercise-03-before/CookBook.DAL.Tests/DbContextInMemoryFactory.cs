using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class DbContextInMemoryFactory: IDbContextFactory<CookBookDbContext>
    {
        private readonly string _databaseName;

        public DbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }
        public CookBookDbContext Create()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);
            return new CookBookDbContext(contextOptionsBuilder.Options);
        }
    }
}