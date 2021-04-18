using CookBook.BL.Models;
using CookBook.DAL.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CookBook.App.Wrappers
{
    public class RecipeWrapper : ModelWrapper<RecipeDetailModel>
    {
        public RecipeWrapper(RecipeDetailModel model)
            : base(model)
        {
            InitializeCollectionProperties(model);
        }

        public string Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string Description
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public TimeSpan Duration
        {
            get => GetValue<TimeSpan>();
            set => SetValue(value);
        }
        public FoodType FoodType
        {
            get => GetValue<FoodType>();
            set => SetValue(value);
        }
        public string ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        private void InitializeCollectionProperties(RecipeDetailModel model)
        {
            if (model.Ingredients == null)
            {
                throw new ArgumentException("Ingredients cannot be null");
            }
            Ingredients = new ObservableCollection<IngredientAmountWrapper>(
                model.Ingredients.Select(e => new IngredientAmountWrapper(e)));

            RegisterCollection(Ingredients, model.Ingredients);
        }

        public ObservableCollection<IngredientAmountWrapper> Ingredients { get; set; } = null!;

        public static implicit operator RecipeWrapper(RecipeDetailModel detailModel)
            => new(detailModel);

        public static implicit operator RecipeDetailModel(RecipeWrapper wrapper)
            => wrapper.Model;

    }
}