using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers
{
    internal static class IngredientAmountMapper
    {
        public static IngredientAmountDetailModel MapEntityToDetailModel(IngredientAmountEntity entity) => entity == null
            ? null
            : new()
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientDescription = entity.Ingredient.Description,
                IngredientImageUrl = entity.Ingredient.ImageUrl,
                Amount = entity.Amount,
                Unit = entity.Unit
            };

        public static IngredientAmountEntity MapDetailModelToEntity(IngredientAmountDetailModel model)
        => model == null
            ? null
            : new()
            {
                Id = model.Id,
                Amount = model.Amount,
                Unit = model.Unit,
                Ingredient = IngredientMapper.MapIngredientAmountDetailModelToEntity(model)
            };
    }
}