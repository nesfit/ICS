using CookBook.BL.Facades;
using CookBook.BL.Models;
using CookBook.Common.Enums;
using CookBook.Common.Tests.Seeds;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests;

public class RecipeFacadeTests : FacadeTestsBase
{
    private readonly IRecipeFacade _facadeSUT;

    public RecipeFacadeTests(ITestOutputHelper output) : base(output)
    {
        _facadeSUT = new RecipeFacade(UnitOfWorkFactory, RecipeModelMapper);
    }

    [Fact]
    public async Task Create_WithWithoutIngredient_EqualsCreated()
    {
        //Arrange
        var model = new RecipeDetailModel()
        {
            Name = "Recipe 1",
            Description = "Testing recipe 1",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.Dessert
        };

        //Act
        var returnedModel = await _facadeSUT.SaveAsync(model);

        //Assert
        Assert.NotEqual(Guid.Empty, returnedModel.Id);
        model.Id = returnedModel.Id;
        Assert.Equivalent(model, returnedModel, strict: true);
    }

    [Fact]
    public async Task Create_WithNonExistingIngredient_Throws()
    {
        //Arrange
        var model = new RecipeDetailModel()
        {
            Name = "Recipe 2",
            Description = "Testing recipe 2",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.Dessert,
            Ingredients = new ObservableCollection<IngredientAmountListModel>()
            {
                new()
                {
                    Id = Guid.Empty,
                    IngredientId = Guid.Empty,
                    IngredientName = "Ingredient 1",
                    IngredientImageUrl = null,
                    Amount = 0,
                    Unit = Unit.None
                }
            }
        };

        //Act & Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _facadeSUT.SaveAsync(model));
    }

    [Fact]
    public async Task Create_WithExistingIngredient_Throws()
    {
        //Arrange
        var model = new RecipeDetailModel()
        {
            Name = "Recipe 2",
            Description = "Testing recipe 2",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.Dessert,
            ImageUrl = "https://d2v9mhsiek5lbq.cloudfront.net/eyJidWNrZXQiOiJsb21hLW1lZGlhLXVrIiwia2V5IjoiZm9vZG5ldHdvcmstaW1hZ2UtOGI5ZWM4YTAtODc1OC00MDcyLTg2YTItMzMzYTA4NTY5NTkwLmpwZyIsImVkaXRzIjp7InJlc2l6ZSI6eyJmaXQiOiJjb3ZlciIsIndpZHRoIjo3NTAsImhlaWdodCI6NDIyfX19",
            Ingredients = new ObservableCollection<IngredientAmountListModel>()
            {
                new ()
                {
                    IngredientName = IngredientSeeds.IngredientEntity1.Name,
                    IngredientId = IngredientSeeds.IngredientEntity1.Id,
                    Amount = 5,
                    Unit = Unit.L,
                    IngredientImageUrl = IngredientSeeds.IngredientEntity1.ImageUrl,
                }
            },
        };

        //Act && Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _facadeSUT.SaveAsync(model));
    }

    [Fact]
    public async Task Create_WithExistingAndNotExistingIngredient_Throws()
    {
        //Arrange
        var model = new RecipeDetailModel()
        {
            Name = "Recipe 2",
            Description = "Testing recipe 2",
            Duration = TimeSpan.FromHours(2),
            FoodType = FoodType.Dessert,
            Ingredients =
            [
                new()
                {
                    IngredientId = Guid.Empty,
                    IngredientName = "Ingredient 1",
                    IngredientImageUrl = null,
                    Amount = 0,
                    Unit = Unit.None
                },

                RecipeModelMapper.MapIngredientAmountToListModel(IngredientAmountSeeds.IngredientAmountEntity1)

            ],
        };

        //Act & Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _facadeSUT.SaveAsync(model));
    }

    [Fact]
    public async Task GetById_FromSeeded_EqualsSeeded()
    {
        //Arrange
        var detailModel = RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity);

        //Act
        var returnedModel = await _facadeSUT.GetAsync(detailModel.Id);

        //Assert
        Assert.Equivalent(detailModel, returnedModel, strict: true);
    }

    [Fact]
    public async Task GetAll_FromSeeded_ContainsSeeded()
    {
        //Arrange
        var listModel = RecipeModelMapper.MapToListModel(RecipeSeeds.RecipeEntity);

        //Act
        var returnedModel = await _facadeSUT.GetAsync();

        //Assert
        Assert.Contains(returnedModel, model =>
        {
            try
            {
                Assert.Equivalent(listModel, model, strict: true);
                return true;
            }
            catch
            {
                return false;
            }
        });
    }

    [Fact]
    public async Task Update_FromSeeded_DoesNotThrow()
    {
        //Arrange
        var detailModel = RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity);
        detailModel.Name = "Changed recipe name";

        //Act
        await _facadeSUT.SaveAsync(RecipeDetailModel.Copy(detailModel, ingredients: []));

        //Assert
        var returnedModel = await _facadeSUT.GetAsync(detailModel.Id);
        Assert.Equal("Changed recipe name", returnedModel?.Name);
    }

    [Fact]
    public async Task Update_Name_FromSeeded_Updated()
    {
        //Arrange
        var detailModel = RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity);
        detailModel.Name = "Changed recipe name 1";

        //Act
        await _facadeSUT.SaveAsync(RecipeDetailModel.Copy(detailModel, ingredients: []));

        //Assert
        var returnedModel = await _facadeSUT.GetAsync(detailModel.Id);
        Assert.Equivalent(detailModel, returnedModel, strict: true);
    }

    [Fact]
    public async Task Update_RemoveIngredients_FromSeeded_NotUpdated()
    {
        //Arrange
        var detailModel = RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity);
        detailModel.Ingredients.Clear();

        //Act
        await _facadeSUT.SaveAsync(detailModel);

        //Assert
        var returnedModel = await _facadeSUT.GetAsync(detailModel.Id);
        Assert.Equivalent(RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity), returnedModel, strict: true);
    }

    [Fact]
    public async Task Update_RemoveOneOfIngredients_FromSeeded_Updated()
    {
        //Arrange
        var detailModel = RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity);
        detailModel.Ingredients.Remove(detailModel.Ingredients.First());

        //Act
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() =>  _facadeSUT.SaveAsync(detailModel));

        //Assert
        var returnedModel = await _facadeSUT.GetAsync(detailModel.Id);
        Assert.Equivalent(RecipeModelMapper.MapToDetailModel(RecipeSeeds.RecipeEntity), returnedModel, strict: true);
    }

    [Fact]
    public async Task AddIngredient_FromSeeded_Inserted()
    {
        // Arrange
        var recipeId = RecipeSeeds.RecipeEntityWithNoIngredients.Id;
        var model = new IngredientAmountListModel
        {
            Id = Guid.NewGuid(),
            IngredientId = IngredientSeeds.Water.Id,
            IngredientName = IngredientSeeds.Water.Name,
            IngredientImageUrl = IngredientSeeds.Water.ImageUrl,
            Amount = 3.5m,
            Unit = Unit.L
        };

        // Act
        await _facadeSUT.AddIngredientAsync(recipeId, model);

        // Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var ingredientAmount = await dbxAssert.IngredientAmountEntities
            .SingleAsync(i => i.Id == model.Id);

        Assert.Equal(recipeId, ingredientAmount.RecipeId);
        Assert.Equal(model.IngredientId, ingredientAmount.IngredientId);
        Assert.Equal(model.Amount, ingredientAmount.Amount);
        Assert.Equal(model.Unit, ingredientAmount.Unit);
    }

    [Fact]
    public async Task UpdateIngredient_FromSeeded_Updated()
    {
        // Arrange
        var recipeId = RecipeSeeds.RecipeForIngredientAmountEntityUpdate.Id;
        var model = new IngredientAmountListModel
        {
            Id = IngredientAmountSeeds.IngredientAmountEntityUpdate.Id,
            IngredientId = IngredientAmountSeeds.IngredientAmountEntityUpdate.IngredientId,
            IngredientName = IngredientSeeds.IngredientEntity1.Name,
            IngredientImageUrl = IngredientSeeds.IngredientEntity1.ImageUrl,
            Amount = 42m,
            Unit = Unit.G
        };

        // Act
        await _facadeSUT.UpdateIngredientAsync(recipeId, model);

        // Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var ingredientAmount = await dbxAssert.IngredientAmountEntities
            .SingleAsync(i => i.Id == model.Id);

        Assert.Equal(recipeId, ingredientAmount.RecipeId);
        Assert.Equal(model.Amount, ingredientAmount.Amount);
        Assert.Equal(model.Unit, ingredientAmount.Unit);
    }

    [Fact]
    public async Task RemoveIngredient_FromSeeded_Deleted()
    {
        // Arrange
        var ingredientAmountId = IngredientAmountSeeds.IngredientAmountEntityDelete.Id;

        // Act
        await _facadeSUT.RemoveIngredientAsync(ingredientAmountId);

        // Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.IngredientAmountEntities.AnyAsync(i => i.Id == ingredientAmountId));
    }

    [Fact]
    public async Task DeleteById_FromSeeded_DoesNotThrow()
    {
        //Act
        await _facadeSUT.DeleteAsync(RecipeSeeds.RecipeEntity.Id);

        //Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Recipes.AnyAsync(i => i.Id == RecipeSeeds.RecipeEntity.Id));
    }

}
