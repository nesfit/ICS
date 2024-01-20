using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public sealed class IngredientFacadeTests : FacadeTestsBase
{
    private readonly IIngredientFacade _ingredientFacadeSUT;

    public IngredientFacadeTests(ITestOutputHelper output) : base(output)
    {
        _ingredientFacadeSUT = new IngredientFacade(UnitOfWorkFactory, IngredientModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new IngredientDetailModel()
        {
            Id = Guid.Empty,
            Name = @"Ingredience 1",
            Description = @"Testovací ingredience",
        };

        var _ = await _ingredientFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Single_SeededWater()
    {
        var ingredients = await _ingredientFacadeSUT.GetAsync();
        var ingredient = ingredients.Single(i => i.Id == IngredientSeeds.Water.Id);

        DeepAssert.Equal(IngredientModelMapper.MapToListModel(IngredientSeeds.Water), ingredient);
    }

    [Fact]
    public async Task GetById_SeededWater()
    {
        var ingredient = await _ingredientFacadeSUT.GetAsync(IngredientSeeds.Water.Id);

        DeepAssert.Equal(IngredientModelMapper.MapToDetailModel(IngredientSeeds.Water), ingredient);
    }

    [Fact]
    public async Task GetById_NonExistent()
    {
        var ingredient = await _ingredientFacadeSUT.GetAsync(IngredientSeeds.EmptyIngredient.Id);

        Assert.Null(ingredient);
    }

    [Fact]
    public async Task SeededWater_DeleteById_Deleted()
    {
        await _ingredientFacadeSUT.DeleteAsync(IngredientSeeds.Water.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Ingredients.AnyAsync(i => i.Id == IngredientSeeds.Water.Id));
    }

    [Fact]
    public async Task Delete_IngredientUsedInRecipe_Throws()
    {
        //Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await _ingredientFacadeSUT.DeleteAsync(IngredientSeeds.IngredientEntity1.Id));
    }

    [Fact]
    public async Task NewIngredient_InsertOrUpdate_IngredientAdded()
    {
        //Arrange
        var ingredient = new IngredientDetailModel()
        {
            Id = Guid.Empty,
            Name = "Water",
            Description = "Mineral water",
        };

        //Act
        ingredient = await _ingredientFacadeSUT.SaveAsync(ingredient);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var ingredientFromDb = await dbxAssert.Ingredients.SingleAsync(i => i.Id == ingredient.Id);
        DeepAssert.Equal(ingredient, IngredientModelMapper.MapToDetailModel(ingredientFromDb));
    }

    [Fact]
    public async Task SeededWater_InsertOrUpdate_IngredientUpdated()
    {
        //Arrange
        var ingredient = new IngredientDetailModel()
        {
            Id = IngredientSeeds.Water.Id,
            Name = IngredientSeeds.Water.Name,
            Description = IngredientSeeds.Water.Description,
        };
        ingredient.Name += "updated";
        ingredient.Description += "updated";

        //Act
        await _ingredientFacadeSUT.SaveAsync(ingredient);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var ingredientFromDb = await dbxAssert.Ingredients.SingleAsync(i => i.Id == ingredient.Id);
        DeepAssert.Equal(ingredient, IngredientModelMapper.MapToDetailModel(ingredientFromDb));
    }
}
