using System;
using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IClassFixture<CookBookDbContextTestsClassSetupFixture>, IDisposable
    {
        public CookBookDbContextTests(CookBookDbContextTestsClassSetupFixture testContext)
        {
            _testContext = testContext;

            testContext.PrepareDatabase();
        }

        private readonly CookBookDbContextTestsClassSetupFixture _testContext;

        [Fact]
        public void AddIngredientTest()
        {
            //Arrange
            var ingredientEntity = new IngredientEntity
            {
                Name = "Salt",
                Description = "Mountain salt"
            };

            //Act
            _testContext.CookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            var retrievedIngredient = dbx.Ingredients.First(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
        }

        [Fact]
        public void AddRecipeTest()
        {
            //Arrange
            var recipeEntity = new RecipeEntity
            {
                Name = "Chicken soup",
                Description = "Grandma's delicious chicken soup."
            };

            //Act
            _testContext.CookBookDbContextSUT.Recipes.Add(recipeEntity);
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            var retrievedRecipe = dbx.Recipes
                .Include(entity => entity.Ingredients)
                .ThenInclude(amount => amount.Ingredient)
                .First(entity => entity.Id == recipeEntity.Id);
            Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
        }

        [Fact]
        public void AddRecipeWithIngredientsTest()
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
            _testContext.CookBookDbContextSUT.Recipes.Add(recipeEntity);
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            var retrievedRecipe = dbx.Recipes
                .Include(entity => entity.Ingredients)
                .ThenInclude(amounts => amounts.Ingredient)
                .First(entity => entity.Id == recipeEntity.Id);
            Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
        }

        [Fact]
        public void DeleteRecipe_DeletesIngredientAmounts()
        {
            //OnCascadeDelete is not supported in in-memory of .NET Core EF 2.x
            if(_testContext.CookBookDbContextSUT.Database.IsInMemory())
            {
                return;
            }

            //Act
            _testContext.CookBookDbContextSUT.Recipes.Remove(_testContext.CookBookDbContextSUT.Recipes.Find(Seeds.Seeds.RecipeEntity.Id));
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            Assert.Equal(0, dbx.Recipes.Count());
            Assert.Equal(0, dbx.IngredientAmountEntities.Count());
            Assert.Equal(2, dbx.Ingredients.Count());
        }

        [Fact]
        public void DeleteIngredient_DeletesIngredientAmounts()
        {
            //OnCascadeDelete is not supported in in-memory of .NET Core EF 2.x
            if (_testContext.CookBookDbContextSUT.Database.IsInMemory())
            {
                return;
            }

            //Act
            _testContext.CookBookDbContextSUT.Ingredients.Remove(_testContext.CookBookDbContextSUT.Ingredients.Find(Seeds.Seeds.IngredientEntity1.Id));
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            Assert.Equal(1, dbx.Recipes.Count());
            Assert.Equal(1, dbx.IngredientAmountEntities.Count());
            Assert.Equal(1, dbx.Ingredients.Count());
        }

        [Fact]
        public void DeleteIngredientAmounts_RecipeAndIngredientSurvives()
        {
            //OnCascadeDelete is not supported in in-memory of .NET Core EF 2.x
            if (_testContext.CookBookDbContextSUT.Database.IsInMemory())
            {
                return;
            }

            //Act
            _testContext.CookBookDbContextSUT.IngredientAmountEntities.Remove(_testContext.CookBookDbContextSUT.IngredientAmountEntities.Find(Seeds.Seeds.IngredientAmountEntity1.Id));
            _testContext.CookBookDbContextSUT.SaveChanges();


            //Assert
            using var dbx = _testContext.DbContextFactory.CreateDbContext();
            Assert.Equal(1,dbx.Recipes.Count());
            Assert.Equal(1, dbx.IngredientAmountEntities.Count());
            Assert.Equal(2,dbx.Ingredients.Count());
        }

        public void Dispose()
        {
            _testContext.TearDownDatabase();
        }
    }
}
