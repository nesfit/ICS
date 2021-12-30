using CookBook.BL.Models;

namespace CookBook.App.Wrappers
{
    public class IngredientWrapper : ModelWrapper<IngredientDetailModel>
    {
        public IngredientWrapper(IngredientDetailModel model)
            : base(model)
        {
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
        public string ImageUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public static implicit operator IngredientWrapper(IngredientDetailModel detailModel)
            => new(detailModel);

        public static implicit operator IngredientDetailModel(IngredientWrapper wrapper)
            => wrapper.Model;
    }
}