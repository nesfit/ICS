using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class IngredientMapper
{
    public IngredientListModel MapToListModel(IngredientEntity? entity)
        => entity is null
        ? IngredientListModel.Empty 
        : new()
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.ImageUrl
        };

    public IEnumerable<IngredientListModel> MapToListModel(IEnumerable<IngredientEntity> entities)
        => entities.Select(MapToListModel);

    public IngredientDetailModel MapToDetailModel(IngredientEntity? entity)
        => entity is null 
            ? IngredientDetailModel.Empty 
            : new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
            };

    public IngredientEntity MapToEntity(IngredientDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
        };
}