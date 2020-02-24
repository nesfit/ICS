using CookBook.DAL;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Factories
{
    public class DbContextFactory : IDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = TasksDB;MultipleActiveResultSets = True;Integrated Security = True; ");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}