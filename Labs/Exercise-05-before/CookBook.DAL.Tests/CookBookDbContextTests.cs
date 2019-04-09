using CookBook.DAL.Entities;
using CookBook.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IClassFixture<CookBookDbContextTestsClassSetupFixture>
    {
        public CookBookDbContextTests(CookBookDbContextTestsClassSetupFixture testContext)
        {
            _testContext = testContext;
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
            using (var dbx = _testContext.CreateCookBookDbContext())
            {
                var retrievedIngredient = dbx.Ingredients.First(entity => entity.Id == ingredientEntity.Id);
                Assert.Equal(ingredientEntity, retrievedIngredient, IngredientEntity.DescriptionNameIdComparer);
            }
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
            using (var dbx = _testContext.CreateCookBookDbContext())
            {
                var retrievedRecipe = dbx.Recipes
                    .Include(entity => entity.Ingredients)
                    .ThenInclude(amount => amount.Ingredient)
                    .First(entity => entity.Id == recipeEntity.Id);
                Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
            }
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
                    new IngredientAmountEntity()
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new IngredientEntity()
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
            using (var dbx = _testContext.CreateCookBookDbContext())
            {
                var retrievedRecipe = dbx.Recipes
                    .Include(entity => entity.Ingredients)
                    .ThenInclude(amounts => amounts.Ingredient)
                    .First(entity => entity.Id == recipeEntity.Id);
                Assert.Equal(recipeEntity, retrievedRecipe, RecipeEntity.RecipeEntityComparer);
            }
        }
    }
}
