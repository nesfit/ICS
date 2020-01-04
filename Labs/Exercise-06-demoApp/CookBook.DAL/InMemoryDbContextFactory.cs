using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using System;

namespace CookBook.DAL
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        private readonly string testDbName;

        public InMemoryDbContextFactory(string testDbName) => this.testDbName = testDbName;

        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseInMemoryDatabase(this.testDbName);

            //optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = {this.testDbName};MultipleActiveResultSets = True;Integrated Security = True; ");

            optionsBuilder.EnableSensitiveDataLogging();
            return new CookBookSeedingDbContext(optionsBuilder.Options);
        }
    }
}