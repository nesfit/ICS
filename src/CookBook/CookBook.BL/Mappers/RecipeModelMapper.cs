using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class RecipeModelMapper
{
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
}