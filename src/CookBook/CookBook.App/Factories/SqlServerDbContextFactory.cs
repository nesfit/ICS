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
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}