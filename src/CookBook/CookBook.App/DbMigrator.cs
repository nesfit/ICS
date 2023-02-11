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

public class SqliteDbMigrator : IDbMigrator 
{
    private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;
    private readonly DALOptions.SqliteOptions _sqliteOptions;

    public SqliteDbMigrator(IDbContextFactory<CookBookDbContext> dbContextFactory, DALOptions dalOptions)
    {
        _dbContextFactory = dbContextFactory;
        _sqliteOptions = dalOptions.Sqlite ?? throw new ArgumentNullException(nameof(dalOptions),$@"{nameof(DALOptions.Sqlite)} are not set");
    }

    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await using CookBookDbContext dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

        if(_sqliteOptions.RecreateDatabseEachTime)
        {
            await dbContext.Database.EnsureDeletedAsync(cancellationToken);
        }

        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
