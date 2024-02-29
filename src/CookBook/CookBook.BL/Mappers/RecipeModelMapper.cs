using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class RecipeModelMapper(IngredientAmountModelMapper ingredientAmountModelMapper)
    : ModelMapperBase<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    public override RecipeListModel MapToListModel(RecipeEntity? entity)
        => entity is null
            ? RecipeListModel.Empty
            : new RecipeListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl
            };

    public override RecipeDetailModel MapToDetailModel(RecipeEntity? entity)
        => entity is null
            ? RecipeDetailModel.Empty
            : new RecipeDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl,
                Ingredients = ingredientAmountModelMapper.MapToListModel(entity.Ingredients)
                    .ToObservableCollection()
            };

    public override RecipeEntity MapToEntity(RecipeDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Duration = model.Duration,
            FoodType = model.FoodType,
            ImageUrl = model.ImageUrl
        };
}
