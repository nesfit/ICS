
using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests.Factories
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
            
            // contextOptionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
            // builder.EnableSensitiveDataLogging();
            
            return new CookBookDbContext(contextOptionsBuilder.Options, _seedTestingData);
        }
    }
}