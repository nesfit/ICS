using CookBook.BL.Mappers;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Factories;
using CookBook.DAL;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
        // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);

        IngredientModelMapper = new IngredientModelMapper();
        IngredientAmountModelMapper = new IngredientAmountModelMapper();
        RecipeModelMapper = new RecipeModelMapper(IngredientAmountModelMapper);

        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
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
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}
