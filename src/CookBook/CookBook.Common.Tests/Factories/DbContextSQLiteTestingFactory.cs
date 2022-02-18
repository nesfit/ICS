using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests.Factories;

public class DbContextSQLiteTestingFactory : IDbContextFactory<CookBookDbContext>
{
    private readonly string _databaseName;
    private readonly bool _seedTestingData;

    public DbContextSQLiteTestingFactory(string databaseName, bool seedTestingData = false)
    {
        _databaseName = databaseName;
        _seedTestingData = seedTestingData;
    }
    public CookBookDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<CookBookDbContext> builder = new();
        builder.UseSqlite($"Data Source={_databaseName};Cache=Shared");
        
        // contextOptionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        // builder.EnableSensitiveDataLogging();
        
        return new CookBookTestingDbContext(builder.Options, _seedTestingData);
    }
}