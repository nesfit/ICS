using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    public static class IngredientMapper
    {
        public static IngredientListModel MapEntityToListModel(IngredientEntity entity)
        {
            return entity == null ? null : new IngredientListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static IngredientDetailModel MapEntityToDetailModel(IngredientEntity entity) =>
            new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

        public static IngredientEntity MapDetailModelToEntity(IngredientDetailModel model) =>
            new()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };
    }
}
