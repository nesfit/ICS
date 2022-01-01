using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CookBook.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CookBookDbContext> builder = new();
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new CookBookDbContext(builder.Options);
        }
    }
}
