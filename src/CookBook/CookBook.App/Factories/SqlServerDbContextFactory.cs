using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.App.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory<CookBookDbContext>
    {
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            //optionsBuilder.UseInMemoryDatabase("aa");
            //optionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
            //optionsBuilder.EnableSensitiveDataLogging();

            return new CookBookDbContext(optionsBuilder.Options, seedTestingData:true);
        }
    }
}