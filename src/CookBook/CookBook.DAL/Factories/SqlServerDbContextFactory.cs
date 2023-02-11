using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories;

public class SqlServerDbContextFactory : IDbContextFactory<CookBookDbContext>
{
    private readonly string _connectionString;
    private readonly bool _seedDemoData;

    public SqlServerDbContextFactory(string connectionString, bool seedDemoData = false)
    {
        _connectionString = connectionString;
        _seedDemoData = seedDemoData;
    }

    public CookBookDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<CookBookDbContext> builder = new();
        builder.UseSqlServer(_connectionString);

        //builder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        //builder.EnableSensitiveDataLogging();

        return new CookBookDbContext(builder.Options, _seedDemoData);
    }
}
