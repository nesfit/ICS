using CookBook.BL.Models;
using CookBook.DAL.Enums;
using System;

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
        public string IngredientName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string IngredientDescription
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

        public static implicit operator IngredientAmountWrapper(IngredientAmountDetailModel detailModel)
            => new(detailModel);

        public static implicit operator IngredientAmountDetailModel(IngredientAmountWrapper wrapper)
            => wrapper.Model;
    }
}