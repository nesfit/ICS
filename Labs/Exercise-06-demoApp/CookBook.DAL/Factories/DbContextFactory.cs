using System;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private String connectionString;

        public DbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}