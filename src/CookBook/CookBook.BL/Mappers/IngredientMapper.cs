using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class IngredientMapper
{
    public IngredientListModel Map(IngredientEntity entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            ImageUrl = entity.ImageUrl
        };

    public IEnumerable<IngredientListModel> Map(IEnumerable<IngredientEntity> entities)
        => entities.Select(Map);
}