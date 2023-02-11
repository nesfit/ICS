using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories;

public class DbContextSqLiteFactory : IDbContextFactory<CookBookDbContext>
{
    private readonly string _databaseName;
    private readonly bool _seedTestingData;

    public DbContextSqLiteFactory(string databaseName, bool seedTestingData = false)
    {
        _databaseName = databaseName;
        _seedTestingData = seedTestingData;
    }
    public CookBookDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<CookBookDbContext> builder = new();
        builder.UseSqlite($"Data Source={_databaseName};Cache=Shared");
        //builder.UseSqlite($"Data Source=Data/Database.db\";Cache=Shared");

        // contextOptionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        // builder.EnableSensitiveDataLogging();

        return new CookBookDbContext(builder.Options, _seedTestingData);
    }
}
