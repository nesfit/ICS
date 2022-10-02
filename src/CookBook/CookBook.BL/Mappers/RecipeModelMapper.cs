using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class RecipeModelMapper
{
    private readonly IngredientAmountMapper ingredientAmountMapper;

    public RecipeModelMapper(IngredientAmountMapper ingredientAmountMapper)
    {
        this.ingredientAmountMapper = ingredientAmountMapper;
    }

    public RecipeListModel MapToListModel(RecipeEntity? entity)
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

    public IEnumerable<RecipeListModel> MapToListModel(IEnumerable<RecipeEntity> entities)
        => entities.Select(MapToListModel);

    public RecipeDetailModel MapToDetailModel(RecipeEntity? entity)
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
                Ingredients = ingredientAmountMapper.MapToDetailModel(entity.Ingredients),
            };

    public RecipeEntity MapToEntity(RecipeDetailModel model)
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