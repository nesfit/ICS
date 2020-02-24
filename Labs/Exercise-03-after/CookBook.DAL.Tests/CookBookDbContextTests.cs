using System;
using System.Linq;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IDisposable
    {
        private readonly DbContextInMemoryFactory _dbContextFactory;
        private readonly CookBookDbContext _cookBookDbContextSUT;

        public CookBookDbContextTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(CookBookDbContextTests));
            _cookBookDbContextSUT = _dbContextFactory.Create();
            _cookBookDbContextSUT.Database.EnsureCreated();
        }

        [Fact]
        public void AddNew_Ingredient_Persisted()
        {
            //Arrange
            var ingredientEntity = new IngredientEntity
            {
                Name = "Salt",
                Description = "Mountain salt"
            };

            //Act
            _cookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            _cookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _dbContextFactory.Create();
            var retrievedIngredient = dbx.Ingredients.Single(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
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
            Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
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
                        Ingredient = new IngredientEntity
                        {
                            Name = "Water",
                            Description = "Filtered Water"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Lime-juice",
                            Description = "Fresh lime-juice"
                        }
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
            Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
        }

        [Fact]
        public void GetAll_Ingredients_WaterRetrieved()
        {
            var fromDb = _cookBookDbContextSUT.Ingredients.Single(i => i.Id == IngredientSeeds.Water.Id);

            Assert.Equal(IngredientSeeds.Water, fromDb, IngredientEntity.DescriptionNameIdComparer);
        }

        public void Dispose()
        {
            _cookBookDbContextSUT?.Dispose();
        }
    }
}