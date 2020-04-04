using CookBook.BL.Factories;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Mapper
{
    internal static class IngredientMapper
    {
        public static IngredientListModel MapListModel(IngredientEntity entity) =>
            entity == null
                ? null
                : new IngredientListModel
                {
                    Id = entity.Id,
                    Name = entity.Name
                };

        public static IngredientDetailModel MapDetailModel(IngredientEntity entity) =>
            entity == null
                ? null
                : new IngredientDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description
                };

        public static IngredientEntity MapEntity(IngredientDetailModel model, IEntityFactory entityFactory = null)
        {
            var entity = (entityFactory ?? new DummyEntityFactory()).Create<IngredientEntity>(model.Id);
            entity.Id = model.Id;
            entity.Description = model.Description;
            entity.Name = model.Name;

            return entity;
        }


        public static IngredientEntity MapEntity(IngredientAmountDetailModel model, IEntityFactory entityFactory = null)
        {
            var entity = (entityFactory ?? new DummyEntityFactory()).Create<IngredientEntity>(model.IngredientId);
            entity.Id = model.IngredientId;
            entity.Description = model.IngredientDescription;
            entity.Name = model.IngredientName;

            return entity;
        }
    }
}