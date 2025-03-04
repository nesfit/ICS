using CookBook.DAL.Options;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Migrator;

public class DbMigrator(IDbContextFactory<CookBookDbContext> dbContextFactory, DALOptions options)
    : IDbMigrator
{
    public void Migrate()
    {
        using CookBookDbContext dbContext = dbContextFactory.CreateDbContext();

        if(options.RecreateDatabaseEachTime)
        {
            dbContext.Database.EnsureDeleted();
        }

        // Ensures that database is created applying the latest state
        // Application of migration later on may fail
        // If you want to use migrations, you should create database by calling  dbContext.Database.Migrate() instead
        dbContext.Database.EnsureCreated();
    }
}
