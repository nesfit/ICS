using System.Linq;
using CookBook.BL.Enums;
using CookBook.BL.Factories;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;

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

        public static RecipeEntity MapToEntity(RecipeDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new DummyEntityFactory()).Create<RecipeEntity>(detailModel.Id);
            entity.Id = detailModel.Id;
            entity.Name = detailModel.Name;
            entity.Description = detailModel.Description;
            entity.Duration = detailModel.Duration;
            entity.FoodType = (DAL.Enums.FoodType) detailModel.FoodType;
            entity.Ingredients = detailModel.Ingredients.Select(model => IngredientAmountMapper.MapEntity(model, entityFactory)).ToList();
            return entity;
        }
    }
}