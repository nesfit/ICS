using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using CookBook.BL.Models;

namespace CookBook.App.Wrappers
{
    public class IngredientWrapper : ModelWrapper<IngredientDetailModel>
    {
        public IngredientWrapper(IngredientDetailModel model)
            : base(model)
        {
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
        public string? ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        
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
        }

        public static implicit operator IngredientWrapper(IngredientDetailModel detailModel)
            => new(detailModel);

        public static implicit operator IngredientDetailModel(IngredientWrapper wrapper)
            => wrapper.Model;
    }
}