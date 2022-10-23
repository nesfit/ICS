using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class RecipeModelMapper : ModelMapperBase<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    private readonly IngredientAmountModelMapper ingredientAmountModelMapper;

    public RecipeModelMapper(IngredientAmountModelMapper ingredientAmountModelMapper)
    {
        this.ingredientAmountModelMapper = ingredientAmountModelMapper;
    }

    public override RecipeListModel MapToListModel(RecipeEntity? entity)
        => entity is null
            ? RecipeListModel.Empty
            : new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl,
            };

    public override RecipeDetailModel MapToDetailModel(RecipeEntity? entity)
        => entity is null
            ? RecipeDetailModel.Empty
            : new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Duration = entity.Duration,
                FoodType = entity.FoodType,
                ImageUrl = entity.ImageUrl,
                Ingredients = ingredientAmountModelMapper.MapToDetailModel(entity.Ingredients),
            };

    public override RecipeEntity MapToEntity(RecipeDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Duration = model.Duration,
            FoodType = model.FoodType,
            ImageUrl = model.ImageUrl,
        };
}