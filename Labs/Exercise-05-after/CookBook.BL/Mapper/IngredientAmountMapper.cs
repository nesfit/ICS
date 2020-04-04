using CookBook.BL.Enums;
using CookBook.BL.Factories;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;

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

        public static IngredientAmountDetailModel MapDetailModel(IngredientAmountEntity entity) =>
            new IngredientAmountDetailModel
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientDescription = entity.Ingredient.Description,
                Amount = entity.Amount,
                Unit = (Unit) entity.Unit
            };

        public static IngredientAmountEntity MapEntity(IngredientAmountDetailModel model,
            IEntityFactory entityFactory = null)
        {
            var entity = (entityFactory ??= new DummyEntityFactory()).Create<IngredientAmountEntity>(model.Id);
            entity.Id = model.Id;
            entity.Amount = model.Amount;
            entity.Unit = (DAL.Enums.Unit)model.Unit;
            entity.Ingredient = IngredientMapper.MapEntity(model, entityFactory);
            return entity;
        }
    }
}