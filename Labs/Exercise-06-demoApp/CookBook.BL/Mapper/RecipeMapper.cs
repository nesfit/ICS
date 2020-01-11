using System.Linq;
using CookBook.BL.Enums;
using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mapper
{
    internal static class RecipeMapper
    {
        public static RecipeDetailModel MapToDetailModel(RecipeEntity entity) =>
            entity == null
                ? null
                : new RecipeDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    FoodType = (FoodType) entity.FoodType,
                    Duration = entity.Duration,
                    Ingredients = entity.Ingredients.Select(IngredientAmountMapper.MapDetailModel).ToList()
                };

        public static RecipeListModel MapToListModel(RecipeEntity entity) =>
            entity == null
                ? null
                : new RecipeListModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Duration = entity.Duration,
                    FoodType = (FoodType) entity.FoodType
                };

        public static RecipeEntity MapToEntity(RecipeDetailModel detailModel)
        {
            var mapToEntity = new RecipeEntity
            {
                Id = detailModel.Id,
                Name = detailModel.Name,
                Description = detailModel.Description,
                Duration = detailModel.Duration,
                FoodType = (DAL.Enums.FoodType) detailModel.FoodType,
                Ingredients = detailModel.Ingredients.Select(IngredientAmountMapper.MapEntity).ToList()
            };

            return mapToEntity;
        }
    }
}