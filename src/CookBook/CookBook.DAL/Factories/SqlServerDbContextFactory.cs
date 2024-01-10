using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories;

public class SqlServerDbContextFactory : IDbContextFactory<CookBookDbContext>
{
    private readonly bool _seedDemoData;
    private readonly DbContextOptionsBuilder<CookBookDbContext> _contextOptionsBuilder = new();

    public SqlServerDbContextFactory(string connectionString, bool seedDemoData = false)
    {
        _seedDemoData = seedDemoData;

        _contextOptionsBuilder.UseSqlServer(connectionString);

        ////Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        //_contextOptionsBuilder.LogTo(System.Console.WriteLine);
        //_contextOptionsBuilder.EnableSensitiveDataLogging();
    }

    public CookBookDbContext CreateDbContext() => new(_contextOptionsBuilder.Options, _seedDemoData);
}
