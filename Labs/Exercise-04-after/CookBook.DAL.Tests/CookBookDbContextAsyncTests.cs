using System;
using System.Linq;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.DAL.Tests
{
    /// <summary>
    /// These tests are duplicity of CookBookDbContextTests!
    /// 
    /// This example is added for the sake of completeness.
    /// Further Async/Await details will be explained in dedicated lecture. 
    /// </summary>
    public sealed class CookBookDbContextAsyncTests : IAsyncLifetime
    {
        private readonly DbContextInMemoryFactory _dbContextFactory;
        private readonly CookBookDbContext _cookBookDbContextSUT;

        public CookBookDbContextAsyncTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(CookBookDbContextTests));
            _cookBookDbContextSUT = _dbContextFactory.Create();
        }

        [Fact]
        public void AddNew_Ingredient_Persisted()
        {
            //Arrange
            var ingredientEntity = new IngredientEntity("Salt", "Mountain salt");

            //Act
            _cookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            _cookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _dbContextFactory.Create();
            var retrievedIngredient = dbx.Ingredients.Single(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public void AddNew_RecipeWithoutIngredients_Persisted()
        {
            //Arrange
            var recipeEntity = new RecipeEntity
            {
                Name = "Chicken soup",
                Description = "Grandma's delicious chicken soup."
            };
            
            //Act
            _cookBookDbContextSUT.Recipes.Add(recipeEntity);
            _cookBookDbContextSUT.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.Create();
            var retrievedRecipe = dbx.Recipes
                .Single(entity => entity.Id == recipeEntity.Id);
            Assert.Equal(recipeEntity, retrievedRecipe);
        }

        [Fact]
        public void AddNew_RecipeWithIngredients_Persisted()
        {
            //Arrange
            var recipeEntity = new RecipeEntity
            {
                Name = "Lemonade",
                Description = "Simple lemon lemonade",
                Ingredients =
                {
                    new IngredientAmountEntity
                    {
                        Amount = 1,
                        Unit = Unit.L,
                        Ingredient = new IngredientEntity("Water","Filtered Water")
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new IngredientEntity("Lime-juice", "Fresh lime-juice")
                    }
                }
            };

            //Act
            _cookBookDbContextSUT.Recipes.Add(recipeEntity);
            _cookBookDbContextSUT.SaveChanges();

            //Assert
            using var dbx = _dbContextFactory.Create();
            var retrievedRecipe = dbx.Recipes
                .Include(entity => entity.Ingredients)
                .ThenInclude(amounts => amounts.Ingredient)
                .Single(entity => entity.Id == recipeEntity.Id);
            Assert.Equal(recipeEntity, retrievedRecipe);
        }

        [Fact]
        public void GetAll_Ingredients_WaterRetrieved()
        {
            var fromDb = _cookBookDbContextSUT.Ingredients.Single(i => i.Id == IngredientSeeds.Water.Id);

            Assert.Equal(IngredientSeeds.Water, fromDb);
        }

        public async Task InitializeAsync() => await _cookBookDbContextSUT.Database.EnsureCreatedAsync();

        public async Task DisposeAsync() => await _cookBookDbContextSUT.DisposeAsync();
    }
}