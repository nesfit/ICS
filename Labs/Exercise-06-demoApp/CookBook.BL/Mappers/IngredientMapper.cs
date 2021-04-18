using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientListModel MapEntityToListModel(IngredientEntity entity)
            => entity == null
                ? null
                : new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    ImageUrl = entity.ImageUrl
                };

        public static IngredientDetailModel MapEntityToDetailModel(IngredientEntity entity)
            => entity == null
                ? null
                : new()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    ImageUrl = entity.ImageUrl
                };

        public static IngredientEntity MapDetailModelToEntity(IngredientDetailModel model)
            => model == null
                ? null
                : new()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl
                };

        public static IngredientEntity MapIngredientAmountDetailModelToEntity(IngredientAmountDetailModel model)
        => model == null
            ? null
            : new()
            {
                Id = model.IngredientId,
                Name = model.IngredientName,
                Description = model.IngredientDescription,
                ImageUrl = model.IngredientImageUrl
            };
    }
}
