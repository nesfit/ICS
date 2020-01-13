using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private string _connectionString;

        public DbContextFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}