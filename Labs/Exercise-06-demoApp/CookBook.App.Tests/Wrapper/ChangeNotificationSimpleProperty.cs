using System;
using CookBook.App.Wrappers;
using CookBook.BL.Enums;
using CookBook.BL.Models;
using Xunit;

namespace CookBook.App.Tests.Wrapper
{
    public class ChangeNotificationSimpleProperty
    {
        public ChangeNotificationSimpleProperty() =>
            _recipeDetailModel = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients =
                {
                    new IngredientAmountDetailModel
                    {
                        IngredientName = "Ingredient 1",
                        IngredientDescription = "Testing Ingredient",
                        Amount = 5
                    }
                }
            };

        private readonly RecipeDetailModel _recipeDetailModel;

        [Fact]
        public void ShouldNotRaisePropertyChangedEventIfPropertyIsSetToSameValue()
        {
            var fired = false;
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(RecipeWrapper.Name))
                {
                    fired = true;
                }
            };
            wrapper.Name = wrapper.Name;
            Assert.False(fired);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            var wrapper = new RecipeWrapper(_recipeDetailModel);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(RecipeWrapper.Name))
                {
                    fired = true;
                }
            };
            wrapper.Name = "new name";
            Assert.True(fired);
        }
    }
}