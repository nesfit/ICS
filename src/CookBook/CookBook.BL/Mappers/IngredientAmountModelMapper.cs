using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public class IngredientAmountModelMapper : ModelMapperBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel>
{
    public override IngredientAmountListModel MapToListModel(IngredientAmountEntity? entity)
        => entity?.Ingredient is null
            ? IngredientAmountListModel.Empty
            : new()
            {
                Id = entity.Id,
            };

    public override IngredientAmountDetailModel MapToDetailModel(IngredientAmountEntity? entity)
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

    public override IngredientAmountEntity MapToEntity(IngredientAmountDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public ICollection<IngredientAmountDetailModel> MapToDetailModel(IEnumerable<IngredientAmountEntity> entities)
        => entities.Select(MapToDetailModel).ToList();

    public IngredientAmountEntity MapToEntity(IngredientAmountDetailModel model, Guid recipeId)
        => new()
        {
            Id = model.Id,
            RecipeId = recipeId,
            IngredientId = model.IngredientId,
            Amount = model.Amount,
            Unit = model.Unit
        };
}