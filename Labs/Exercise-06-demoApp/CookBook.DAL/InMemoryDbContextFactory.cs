using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        private readonly string _testDbName;

        public InMemoryDbContextFactory(string testDbName) => _testDbName = testDbName;

        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseInMemoryDatabase(_testDbName);

            //optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = {this.testDbName};MultipleActiveResultSets = True;Integrated Security = True; ");

            optionsBuilder.EnableSensitiveDataLogging();
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}