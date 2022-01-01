
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class DbContextInMemoryFactory: IDbContextFactory<CookBookDbContext>
    {
        private readonly string _databaseName;

        public DbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }

        public CookBookDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<CookBookDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);

            return new CookBookDbContext(contextOptionsBuilder.Options);
        }
    }
}