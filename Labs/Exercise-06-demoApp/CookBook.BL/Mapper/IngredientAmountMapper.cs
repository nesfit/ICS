using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    internal static class IngredientAmountMapper
    {
        public static IngredientListModel MapListModel(IngredientEntity entity) =>
            new IngredientListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

        public static IngredientDetailModel MapDetailModel(IngredientEntity entity) =>
            new IngredientDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

        public static IngredientAmountEntity MapEntity(IngredientAmountDetailModel model) =>
            new IngredientAmountEntity
            {
                Id = model.Id,
                Amount = model.Amount,
                Unit = (CookBook.DAL.Enums.Unit)model.Unit,
                Ingredient = IngredientMapper.MapEntity(model)
            };

        public static IngredientAmountDetailModel MapDetailModel(IngredientAmountEntity entity) =>
            new IngredientAmountDetailModel
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientDescription = entity.Ingredient.Description
            };
    }
}