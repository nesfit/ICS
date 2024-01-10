using CookBook.DAL.Factories;
using CookBook.DAL.Mappers;
using CookBook.DAL.Migrator;
using CookBook.DAL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, DALOptions options)
    {
        services.AddSingleton(options);

        if (options is null)
        {
            throw new InvalidOperationException("No persistence provider configured");
        }

        if (string.IsNullOrEmpty(options.DatabaseDirectory))
        {
            throw new InvalidOperationException($"{nameof(options.DatabaseDirectory)} is not set");
        }
        if (string.IsNullOrEmpty(options.DatabaseName))
        {
            throw new InvalidOperationException($"{nameof(options.DatabaseName)} is not set");
        }

        services.AddSingleton<IDbContextFactory<CookBookDbContext>>(_ =>
            new DbContextSqLiteFactory(options.DatabaseFilePath, options?.SeedDemoData ?? false));
        services.AddSingleton<IDbMigrator, DbMigrator>();

        services.AddSingleton<IngredientEntityMapper>();
        services.AddSingleton<IngredientAmountEntityMapper>();
        services.AddSingleton<RecipeEntityMapper>();

        return services;
    }
}
