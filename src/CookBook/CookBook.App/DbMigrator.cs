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
    private readonly IDbContextFactory<CookBookDbContext> dbContextFactory;
    private readonly DALOptions.SqliteOptions dalOptions;

    public SqliteDbMigrator(IDbContextFactory<CookBookDbContext> dbContextFactory, IOptions<DALOptions.SqliteOptions> dalOptions)
    {
        this.dbContextFactory = dbContextFactory;
        this.dalOptions = dalOptions.Value;
    }

    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        using var dbContext = dbContextFactory.CreateDbContext();

        if(dalOptions.RecreateDatabseEachTime)
        {
            await dbContext.Database.EnsureDeletedAsync();
        }

        await dbContext.Database.EnsureCreatedAsync(cancellationToken);
    }
}
