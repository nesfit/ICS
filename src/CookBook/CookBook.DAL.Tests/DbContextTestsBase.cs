using CookBook.Common.Tests;
using CookBook.Common.Tests.Seeds;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteFactory(GetType().FullName!);
        CookBookDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<CookBookDbContext> DbContextFactory { get; }
    protected CookBookDbContext CookBookDbContextSUT { get; }


    public async Task InitializeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.Database.EnsureCreatedAsync();

        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        dbx
            .SeedIngredients()
            .SeedRecipes()
            .SeedIngredientAmounts();
        await dbx.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.DisposeAsync();
    }
}
