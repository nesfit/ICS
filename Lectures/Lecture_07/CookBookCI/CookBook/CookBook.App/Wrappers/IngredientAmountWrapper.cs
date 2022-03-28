using CookBook.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CookBook.Common.Enums;

namespace CookBook.App.Wrappers
{
    public class IngredientAmountWrapper : ModelWrapper<IngredientAmountDetailModel>
    {
        public IngredientAmountWrapper(IngredientAmountDetailModel model)
            : base(model)
        {
        }

        public Guid IngredientId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }
        public string? IngredientName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string? IngredientDescription
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public double Amount
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public Unit Unit
        {
            get => GetValue<Unit>();
            set => SetValue(value);
        }
        
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(IngredientName))
            {
                yield return new ValidationResult($"{nameof(IngredientName)} is required", new[] {nameof(IngredientName)});
            }

            if (string.IsNullOrWhiteSpace(IngredientDescription))
            {
                yield return new ValidationResult($"{nameof(IngredientDescription)} is required", new[] {nameof(IngredientDescription)});
            }
            if (Amount > 0)
            {
                yield return new ValidationResult($"{nameof(Amount)} is required", new[] {nameof(Amount)});
            }
            if (Unit != Unit.None)
            {
                yield return new ValidationResult($"{nameof(Unit)} is required", new[] {nameof(Amount)});
            }
        }

        public static implicit operator IngredientAmountWrapper(IngredientAmountDetailModel detailModel)
            => new(detailModel);

        public static implicit operator IngredientAmountDetailModel(IngredientAmountWrapper wrapper)
            => wrapper.Model;
    }
}