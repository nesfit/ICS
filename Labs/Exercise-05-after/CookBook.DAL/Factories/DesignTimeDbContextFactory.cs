using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class DesignTimeDbContextFactory : INamedDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<CookBookDbContext>();
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new CookBookDbContext(builder.Options);
        }
    }
}
