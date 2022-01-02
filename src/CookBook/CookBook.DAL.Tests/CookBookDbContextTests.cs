using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CookBook.Common.Enums;
using CookBook.Common.Tests;
using CookBook.DAL.Factories;
using Xunit;

namespace CookBook.DAL.Tests
{
    public sealed class CookBookDbContextTests : IDisposable
    {
        private readonly DbContextInMemoryFactory _dbContextFactory;
        private readonly CookBookDbContext _cookBookDbContextSUT;

        public CookBookDbContextTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(CookBookDbContextTests), seedTestingData: true);
            _cookBookDbContextSUT = _dbContextFactory.CreateDbContext();
            _cookBookDbContextSUT.Database.EnsureCreated();
        }

        [Fact]
        public void AddNew_Ingredient_Persisted()
        {
            //Arrange
            IngredientEntity? ingredientEntity = new IngredientEntity
            {
                Name = "Salt",
                Description = "Mountain salt",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Salt_shaker_on_white_background.jpg/800px-Salt_shaker_on_white_background.jpg"
            };

            //Act
            _cookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            _cookBookDbContextSUT.SaveChanges();


            //Assert
            using CookBookDbContext? dbx = _dbContextFactory.CreateDbContext();
            IngredientEntity? retrievedIngredient = dbx.Ingredients.Single(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public void AddNew_RecipeWithoutIngredients_Persisted()
        {
            //Arrange
            RecipeEntity? recipeEntity = new RecipeEntity
            {
                Name = "Chicken soup",
                Description = "Grandma's delicious chicken soup."
            };

            //Act
            _cookBookDbContextSUT.Recipes.Add(recipeEntity);
            _cookBookDbContextSUT.SaveChanges();

            //Assert
            using CookBookDbContext? dbx = _dbContextFactory.CreateDbContext();
            RecipeEntity? retrievedRecipe = dbx.Recipes
                .Single(entity => entity.Id == recipeEntity.Id);
            DeepAssert.Equal(recipeEntity, retrievedRecipe);
        }

        [Fact]
        public void AddNew_RecipeWithIngredients_Persisted()
        {
            //Arrange
            RecipeEntity? recipeEntity = new RecipeEntity
            {
                Name = "Lemonade",
                Description = "Simple lemon lemonade",
                Ingredients =
                {
                    new IngredientAmountEntity
                    {
                        Amount = 1,
                        Unit = Unit.L,
                        Ingredient = new()
                        {
                            Name = "Water",
                            Description = "Filtered Water",
                            ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new()
                        {
                            Name = "Lime-juice",
                            Description = "Fresh lime-juice",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/68/Lime-Whole-Split.jpg/640px-Lime-Whole-Split.jpg"
                        }
                    }
                }
            };

            //Act
            _cookBookDbContextSUT.Recipes.Add(recipeEntity);
            _cookBookDbContextSUT.SaveChanges();

            //Assert
            using CookBookDbContext? dbx = _dbContextFactory.CreateDbContext();
            RecipeEntity? retrievedRecipe = dbx.Recipes
                .Include(entity => entity.Ingredients)
                .ThenInclude(amounts => amounts.Ingredient)
                .Single(entity => entity.Id == recipeEntity.Id);
            DeepAssert.Equal(recipeEntity, retrievedRecipe);
        }

        [Fact]
        public void GetAll_Ingredients_WaterRetrieved()
        {
            IngredientEntity? fromDb = _cookBookDbContextSUT.Ingredients.Single(i => i.Id == IngredientSeeds.Water.Id);

            Assert.Equal(IngredientSeeds.Water, fromDb);
        }

        public void Dispose() => _cookBookDbContextSUT?.Dispose();
    }
}