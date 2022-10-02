using System;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.BL.Mappers;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Factories;
using CookBook.DAL;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public class  CRUDFacadeTestsBase : IAsyncLifetime
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

        UnitOfWorkFactory = new UnitOfWorkFactory(IngredientEntityMapper, IngredientAmountEntityMapper, RecipeEntityMapper, DbContextFactory);


        var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[]
                {
                    typeof(BusinessLogic),
                });

                // TODO: remove this when AutoMapper is no longer needed
                //cfg.AddCollectionMappers();
                
                using var dbContext = DbContextFactory.CreateDbContext();
                //cfg.UseEntityFrameworkCoreModel<CookBookDbContext>(dbContext.Model);
            }
        );
        Mapper = new Mapper(configuration);
        Mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    protected IDbContextFactory<CookBookDbContext> DbContextFactory { get; }
    
    protected IngredientEntityMapper IngredientEntityMapper { get; }
    protected IngredientAmountEntityMapper IngredientAmountEntityMapper { get; }
    protected RecipeEntityMapper RecipeEntityMapper { get; }

    protected IngredientModelMapper IngredientModelMapper { get; }
    protected IngredientAmountModelMapper IngredientAmountModelMapper { get; }
    protected RecipeModelMapper RecipeModelMapper { get; }
    protected Mapper Mapper { get; }
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