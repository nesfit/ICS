
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class DbContextInMemoryFactory: IDbContextFactory<CookBookDbContext>
    {
        private readonly string _databaseName;
        private readonly bool _seedTestingData;

        public DbContextInMemoryFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }

        public CookBookDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<CookBookDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);

            return new CookBookDbContext(contextOptionsBuilder.Options, _seedTestingData);
        }
    }
}