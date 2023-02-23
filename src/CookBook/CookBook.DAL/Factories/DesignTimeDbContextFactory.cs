using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CookBook.DAL.Factories;

/// <summary>
///     EF Core CLI migration generation uses this DbContext to create model and migration
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
{
    public CookBookDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CookBookDbContext> builder = new();

        // // Use for LocalDB migrations
        // builder.UseSqlServer(
        //     @"Data Source=(LocalDB)\MSSQLLocalDB;
        //         Initial Catalog = CookBook;
        //         MultipleActiveResultSets = True;
        //         Integrated Security = True;
        //         Encrypt = False;
        //         TrustServerCertificate = True;");

        builder.UseSqlite($"Data Source=CookBook;Cache=Shared");

        return new CookBookDbContext(builder.Options);
    }
}
