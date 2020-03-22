using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = CookBook;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}