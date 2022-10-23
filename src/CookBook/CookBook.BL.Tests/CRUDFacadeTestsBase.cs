using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Factories;
using CookBook.DAL;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public class CRUDFacadeTestsBase : IAsyncLifetime
{
    protected CRUDFacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
        // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
        IngredientEntityMapper = new IngredientEntityMapper();
        IngredientAmountEntityMapper = new IngredientAmountEntityMapper();
        RecipeEntityMapper = new RecipeEntityMapper();

        IngredientModelMapper = new IngredientModelMapper();
        IngredientAmountModelMapper = new IngredientAmountModelMapper();
        RecipeModelMapper = new RecipeModelMapper(IngredientAmountModelMapper);

        DbContextFactory = new DbContextSQLiteTestingFactory(GetType().FullName!, seedTestingData: true);

        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
    }

    protected IDbContextFactory<CookBookDbContext> DbContextFactory { get; }

    protected IngredientEntityMapper IngredientEntityMapper { get; }
    protected IngredientAmountEntityMapper IngredientAmountEntityMapper { get; }
    protected RecipeEntityMapper RecipeEntityMapper { get; }

    protected IModelMapper<IngredientEntity, IngredientListModel, IngredientDetailModel> IngredientModelMapper { get; }
    protected IngredientAmountModelMapper IngredientAmountModelMapper { get; }
    protected IModelMapper<RecipeEntity, RecipeListModel, RecipeDetailModel> RecipeModelMapper { get; }
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