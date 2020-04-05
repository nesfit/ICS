using Microsoft.EntityFrameworkCore.Design;

namespace CookBook.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDbContextFactory
    {
        public CookBookDbContext CreateDbContext()
            => new SqlServerDbContextFactory(@"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = MigrationDb;MultipleActiveResultSets = True;Integrated Security = True; ")
                .CreateDbContext();
    }
}