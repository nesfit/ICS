using CookBook.BL.Mappers;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Seeds;
using CookBook.DAL;
using CookBook.DAL.Factories;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    private readonly ServiceProvider _serviceProvider;

    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteFactory(GetType().FullName!);

        IngredientModelMapper = new IngredientModelMapper();
        IngredientAmountModelMapper = new IngredientAmountModelMapper();
        RecipeModelMapper = new RecipeModelMapper(IngredientAmountModelMapper);

        var services = new ServiceCollection();
        services.AddSingleton<IngredientEntityMapper>();
        services.AddSingleton<IngredientAmountEntityMapper>();
        services.AddSingleton<RecipeEntityMapper>();
        _serviceProvider = services.BuildServiceProvider();

        UnitOfWorkFactory = new UnitOfWorkFactory(
            DbContextFactory,
            _serviceProvider.GetRequiredService<IServiceScopeFactory>());
    }

    protected IDbContextFactory<CookBookDbContext> DbContextFactory { get; }

    protected IngredientModelMapper IngredientModelMapper { get; }
    protected IngredientAmountModelMapper IngredientAmountModelMapper { get; }
    protected RecipeModelMapper RecipeModelMapper { get; }
    protected UnitOfWorkFactory UnitOfWorkFactory { get; }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();

        dbx.SeedIngredients()
            .SeedRecipes()
            .SeedIngredientAmounts();
        await dbx.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await _serviceProvider.DisposeAsync();
    }
}
