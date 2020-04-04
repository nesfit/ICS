using Microsoft.EntityFrameworkCore.Design;

namespace CookBook.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
    {
        public CookBookDbContext CreateDbContext(string[] args) 
            => new SqlServerDbContextFactory(@"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = MigrationDb;MultipleActiveResultSets = True;Integrated Security = True; ")
                .CreateDbContext();
    }
}