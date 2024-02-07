using CookBook.BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using CookBook.App.Extensions;
using CookBook.Common.Enums;

namespace CookBook.App.Wrappers
{
    public class RecipeWrapper : ModelWrapper<RecipeDetailModel>
    {
        public RecipeWrapper(RecipeDetailModel model)
            : base(model)
        {
            InitializeCollectionProperties(model);
        }

        public string? Name
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? Description
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
        public string? ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        private void InitializeCollectionProperties(RecipeDetailModel model)
        {
            if (model.Ingredients is null)
            {
                throw new ArgumentException("Ingredients cannot be null");
            }
            Ingredients.AddRange(model.Ingredients.Select(e => new IngredientAmountWrapper(e)));

            RegisterCollection(Ingredients, model.Ingredients);
        }

        public ObservableCollection<IngredientAmountWrapper> Ingredients { get; set; } = new();

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult($"{nameof(Name)} is required", new[] {nameof(Name)});
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                yield return new ValidationResult($"{nameof(Description)} is required", new[] {nameof(Description)});
            }
            if (Duration == default)
            {
                yield return new ValidationResult($"{nameof(Duration)} is required", new[] {nameof(Duration)});
            }
        }

        public static implicit operator RecipeWrapper(RecipeDetailModel detailModel)
            => new(detailModel);

        public static implicit operator RecipeDetailModel(RecipeWrapper wrapper)
            => wrapper.Model;
    }
}