using CookBook.App.Options;
using CookBook.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookBook.App;

interface IDbMigrator
{
    public void Migrate();
    public Task MigrateAsync(CancellationToken cancellationToken);
}

public class NoneDbMigrator : IDbMigrator
{
    public void Migrate() { }
    public Task MigrateAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

public class SqliteDbMigrator(IDbContextFactory<CookBookDbContext> dbContextFactory, DALOptions dalOptions)
    : IDbMigrator
{
    private readonly SqliteOptions _sqliteOptions = dalOptions.Sqlite ?? throw new ArgumentNullException(nameof(dalOptions),$@"{nameof(DALOptions.Sqlite)} are not set");

    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await using CookBookDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        if(_sqliteOptions.RecreateDatabaseEachTime)
        {
            await dbContext.Database.EnsureDeletedAsync(cancellationToken);
        }

        // Ensures that database is created applying the latest state
        // Application of migration later on may fail
        // If you want to use migrations, you should create database by calling  dbContext.Database.MigrateAsync(cancellationToken) instead
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
