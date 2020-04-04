using System;
using System.Linq;
using CookBook.App.Wrappers;
using CookBook.BL.Enums;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.App.Tests.Wrapper
{
    public class ChangeNotificationCollectionProperty
    {
        private readonly RecipeDetailModel _recipeDetailModel;
        private readonly IngredientAmountDetailModel _ingredientAmountDetailModel;

        public ChangeNotificationCollectionProperty()
        {
            _ingredientAmountDetailModel = new IngredientAmountDetailModel
            {
                IngredientName = "Ingredient 1",
                IngredientDescription = "Testing Ingredient",
                Amount = 5
            };

            _recipeDetailModel = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients =
                {
                    _ingredientAmountDetailModel,
                    new IngredientAmountDetailModel
                    {
                        IngredientName = "Ingredient 2",
                        IngredientDescription = "Testing Ingredient 2",
                        Amount = 6
                    }
                }
            };
        }

        [Fact]
        public void ShouldInitializeIngredientsProperty()
        {
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            Assert.NotNull(wrapper.Ingredients);
            CheckIfModelCollectionIsInSync(wrapper);
        }

        [Fact]
        public void ShouldBeInSyncAfterRemovingIngredient()
        {
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            var ingredientToRemove = wrapper.Ingredients.Single(ew => ew.Model == _ingredientAmountDetailModel);
            wrapper.Ingredients.Remove(ingredientToRemove);
            CheckIfModelCollectionIsInSync(wrapper);
        }

        [Fact]
        public void ShouldBeInSyncAfterAddingIngredient()
        {
            _recipeDetailModel.Ingredients.Remove(_ingredientAmountDetailModel);
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            wrapper.Ingredients.Add(new IngredientAmountWrapper(_ingredientAmountDetailModel));
            CheckIfModelCollectionIsInSync(wrapper);
        }

        private void CheckIfModelCollectionIsInSync(RecipeWrapper wrapper)
        {
            Assert.Equal(_recipeDetailModel.Ingredients.Count, wrapper.Ingredients.Count);
            Assert.True(_recipeDetailModel.Ingredients.All(e =>
                wrapper.Ingredients.Any(we => we.Model == e)));
        }
    }
}