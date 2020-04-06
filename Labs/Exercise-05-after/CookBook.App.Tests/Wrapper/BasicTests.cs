using System;
using CookBook.App.Wrappers;
using CookBook.BL.Enums;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.App.Tests.Wrapper
{
    public class BasicTests
    {
        private readonly RecipeDetailModel _recipeDetailModel;

        public BasicTests() =>
            _recipeDetailModel = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients = {
                    new IngredientAmountDetailModel
                    {
                        IngredientName = "Ingredient 1",
                        IngredientDescription = "Testing Ingredient",
                        Amount = 5,
                    }
                }
            };

        [Fact]
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            Assert.Equal(_recipeDetailModel, wrapper.Model);
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>("model",() => new RecipeWrapper(null));
        }

        [Fact]
        public void ShouldThrowArgumentExceptionIfCollectionIsNull()
        {
            _recipeDetailModel.Ingredients = null;
            var ex = Assert.Throws<ArgumentException>( () => new RecipeWrapper(_recipeDetailModel));
            Assert.Equal("Ingredients cannot be null", ex.Message);
        }

        [Fact]
        public void ShouldGetValueOfUnderlyingModelProperty()
        {
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            Assert.Equal(_recipeDetailModel.Name, wrapper.Name);
        }

        [Fact]
        public void ShouldSetValueOfUnderlyingModelProperty()
        {
            var _ = new RecipeWrapper(_recipeDetailModel) {Name = "Recipe 1"};
            Assert.Equal("Recipe 1", _recipeDetailModel.Name);
        }
    }
}
