using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace School.DAL.Factories
{
    /// <summary>
    /// Allows to use `dotnet ef migrations add xxx`
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1
    /// https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SchoolDbContext>(); 
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = School;
                MultipleActiveResultSets = True;
                Integrated Security = True; ");

            return new SchoolDbContext(builder.Options);
        }
    }
}
