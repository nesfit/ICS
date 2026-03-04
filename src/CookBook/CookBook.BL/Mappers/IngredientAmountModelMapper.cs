using CookBook.BL.Models;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class IngredientAmountModelMapper :
    ModelMapperBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountListModel>
{
    public override IngredientAmountListModel MapToListModel(IngredientAmountEntity? entity)
        => entity?.Ingredient is null
            ? IngredientAmountListModel.Empty
            : new IngredientAmountListModel
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientImageUrl = entity.Ingredient.ImageUrl,
                Amount = entity.Amount,
                Unit = entity.Unit
            };

    public override IngredientAmountListModel MapToDetailModel(IngredientAmountEntity? entity)
        => MapToListModel(entity);

    public void MapToExistingListModel(IngredientAmountListModel existingListModel,
        IngredientListModel ingredient)
    {
        existingListModel.IngredientId = ingredient.Id;
        existingListModel.IngredientName = ingredient.Name;
        existingListModel.IngredientImageUrl = ingredient.ImageUrl;
    }

    public override IngredientAmountEntity MapToEntity(IngredientAmountListModel model)
        => MapToEntity(model.Id, Guid.Empty, model.IngredientId, model.Amount, model.Unit);

    public IngredientAmountEntity MapToEntity(IngredientAmountListModel model, Guid recipeId)
        => MapToEntity(model.Id, recipeId, model.IngredientId, model.Amount, model.Unit);

    private static IngredientAmountEntity MapToEntity(
        Guid id,
        Guid recipeId,
        Guid ingredientId,
        decimal amount,
        Unit unit)
        => new()
        {
            Id = id,
            RecipeId = recipeId,
            IngredientId = ingredientId,
            Amount = amount,
            Unit = unit,
            Recipe = null!,
            Ingredient = null!
        };
}
