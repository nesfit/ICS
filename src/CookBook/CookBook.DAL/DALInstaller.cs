using CookBook.DAL.Factories;
using CookBook.DAL.Mappers;
using CookBook.DAL.Migrator;
using CookBook.DAL.Options;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CookBook.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddSingleton<IDbContextFactory<CookBookDbContext>>(serviceProvider =>
        {
            var dalOptions = serviceProvider.GetRequiredService<IOptions<DALOptions>>();
            return new DbContextSqLiteFactory(dalOptions.Value.DatabaseFilePath);
        });
        services.AddSingleton<IDbMigrator, DbMigrator>();
        services.AddSingleton<IDbSeeder, DbSeeder>();

        services.AddSingleton<IngredientEntityMapper>();
        services.AddSingleton<IngredientAmountEntityMapper>();
        services.AddSingleton<RecipeEntityMapper>();

        return services;
    }
}
