using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class IngredientAmountMapper
{
    public IngredientAmountDetailModel MapToDetailModel(IngredientAmountEntity? entity)
        => entity?.Ingredient is null
            ? IngredientAmountDetailModel.Empty
            : new()
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientDescription = entity.Ingredient.Description,
                IngredientImageUrl = entity.Ingredient.ImageUrl,
                Amount = entity.Amount,
                Unit = entity.Unit,
            };

    public ICollection<IngredientAmountDetailModel> MapToDetailModel(IEnumerable<IngredientAmountEntity> entities)
        => entities.Select(MapToDetailModel).ToList();
}