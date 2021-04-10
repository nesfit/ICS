using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class SqlServerDbContextFactory : INamedDbContextFactory<CookBookDbContext>
    {
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CookBookDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}