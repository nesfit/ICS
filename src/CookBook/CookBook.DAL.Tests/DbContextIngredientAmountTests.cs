using CookBook.Common.Enums;
using CookBook.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class DbContextIngredientAmountTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task GetAll_IngredientAmounts_ForRecipe()
    {
        //Act
        var ingredientAmounts = await CookBookDbContextSUT.IngredientAmountEntities
            .Where(i => i.RecipeId == RecipeSeeds.RecipeEntity.Id)
            .ToArrayAsync();

        //Assert
        Assert.Contains(IngredientAmountSeeds.IngredientAmountEntity1 with { Recipe = null!, Ingredient = null!}, ingredientAmounts);
        Assert.Contains(IngredientAmountSeeds.IngredientAmountEntity2 with { Recipe = null!, Ingredient = null!}, ingredientAmounts);
    }

    [Fact]
    public async Task GetAll_IngredientAmounts_IncludingIngredients_ForRecipe()
    {
        //Act
        var ingredientAmounts = await CookBookDbContextSUT.IngredientAmountEntities
            .Where(i => i.RecipeId == IngredientAmountSeeds.IngredientAmountEntity1.RecipeId)
            .Include(i => i.Ingredient)
            .ToArrayAsync();

        //Assert
        Assert.Contains(IngredientAmountSeeds.IngredientAmountEntity1 with {Recipe = null!}, ingredientAmounts);
        Assert.Contains(IngredientAmountSeeds.IngredientAmountEntity2 with {Recipe = null!}, ingredientAmounts);
    }

    [Fact]
    public async Task Update_IngredientAmount_Persisted()
    {
        //Arrange
        var baseEntity = IngredientAmountSeeds.IngredientAmountEntityUpdate;
        var entity =
            baseEntity with
            {
                Amount = baseEntity.Amount + 1,
                Unit = Unit.None,
                Recipe = null!,
                Ingredient = null!
            };

        //Act
        CookBookDbContextSUT.IngredientAmountEntities.Update(entity);
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntity = await dbx.IngredientAmountEntities.SingleAsync(i => i.Id == entity.Id);
        Assert.Equal(entity, actualEntity);
    }

    [Fact]
    public async Task Delete_IngredientAmount_Deleted()
    {
        //Arrange
        var baseEntity = IngredientAmountSeeds.IngredientAmountEntityDelete;

        //Act
        CookBookDbContextSUT.IngredientAmountEntities.Remove(baseEntity);
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        Assert.False(await CookBookDbContextSUT.IngredientAmountEntities.AnyAsync(i => i.Id == baseEntity.Id));
    }

    [Fact]
    public async Task DeleteById_IngredientAmount_Deleted()
    {
        //Arrange
        var baseEntity = IngredientAmountSeeds.IngredientAmountEntityDelete;

        //Act
        CookBookDbContextSUT.Remove(
            CookBookDbContextSUT.IngredientAmountEntities.Single(i => i.Id == baseEntity.Id));
        await CookBookDbContextSUT.SaveChangesAsync();

        //Assert
        Assert.False(await CookBookDbContextSUT.IngredientAmountEntities.AnyAsync(i => i.Id == baseEntity.Id));
    }

    [Fact]
    public async Task Add_DuplicateIngredientForRecipe_Throws()
    {
        // Arrange
        var duplicate = IngredientAmountSeeds.IngredientAmountEntity1 with
        {
            Id = Guid.Parse("8d0e0946-5834-4f22-8d0b-436d0bc29de5"),
            Recipe = null!,
            Ingredient = null!
        };

        // Act & Assert
        CookBookDbContextSUT.IngredientAmountEntities.Add(duplicate);
        await Assert.ThrowsAsync<DbUpdateException>(() => CookBookDbContextSUT.SaveChangesAsync());
    }
}
