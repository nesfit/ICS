using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory
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