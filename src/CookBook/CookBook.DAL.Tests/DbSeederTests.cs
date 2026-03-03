using CookBook.DAL.Options;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class DbSeederTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task Seed_WhenCalledTwice_DoesNotDuplicateDemoData()
    {
        // Arrange
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.Database.EnsureCreatedAsync();

        var options = Microsoft.Extensions.Options.Options.Create(new DALOptions
        {
            SeedDemoData = true
        });
        var seeder = new DbSeeder(DbContextFactory, options);

        // Act
        seeder.Seed();
        seeder.Seed();

        // Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        Assert.Equal(2, await dbx.Ingredients.CountAsync());
        Assert.Single(await dbx.Recipes.ToListAsync());
        Assert.Equal(2, await dbx.IngredientAmountEntities.CountAsync());
    }
}
