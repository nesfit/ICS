using CookBook.App.Options;
using CookBook.DAL.Factories;
using CookBook.DAL;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CookBook.App;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
    {
        DALOptions dalOptions = new();
        configuration.GetSection("CookBook:DAL").Bind(dalOptions);

        services.AddSingleton<DALOptions>(dalOptions);

        if (dalOptions.LocalDb is null && dalOptions.Sqlite is null)
        {
            throw new InvalidOperationException("No persistence provider configured");
        }

        if (!(dalOptions.LocalDb?.Enabled ?? false) && !(dalOptions.Sqlite?.Enabled ?? false))
        {
            throw new InvalidOperationException("No persistence provider enabled");
        }

        if ((dalOptions.LocalDb?.Enabled ?? false) && (dalOptions.Sqlite?.Enabled ?? false))
        {
            throw new InvalidOperationException("Both persistence providers enabled");
        }

        if (dalOptions.LocalDb?.Enabled ?? false)
        {
            services.AddSingleton<IDbContextFactory<CookBookDbContext>>(provider => new SqlServerDbContextFactory(dalOptions.LocalDb.ConnectionString ));
            services.AddSingleton<IDbMigrator, NoneDbMigrator>();
        }

        if (dalOptions.Sqlite?.Enabled ?? false)
        {
            if (dalOptions.Sqlite.DatabaseName is null)
            {
                throw new InvalidOperationException($"{nameof(dalOptions.Sqlite.DatabaseName)} is not set");

            }
            services.AddSingleton<IDbContextFactory<CookBookDbContext>>(provider => new DbContextSqLiteFactory(dalOptions.Sqlite.DatabaseName!, dalOptions?.Sqlite?.SeedDemoData ?? false));
            services.AddSingleton<IDbMigrator, SqliteDbMigrator>();
        }

        services.AddSingleton<IngredientEntityMapper>();
        services.AddSingleton<IngredientAmountEntityMapper>();
        services.AddSingleton<RecipeEntityMapper>();

        return services;
    }
}
