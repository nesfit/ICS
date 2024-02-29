using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public class IngredientAmountModelMapper :
    ModelMapperBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel>
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

    public override IngredientAmountDetailModel MapToDetailModel(IngredientAmountEntity? entity)
        => entity?.Ingredient is null
            ? IngredientAmountDetailModel.Empty
            : new IngredientAmountDetailModel
            {
                Id = entity.Id,
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                IngredientDescription = entity.Ingredient.Description,
                IngredientImageUrl = entity.Ingredient.ImageUrl,
                Amount = entity.Amount,
                Unit = entity.Unit
            };

    public IngredientAmountListModel MapToListModel(IngredientAmountDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            IngredientId = detailModel.IngredientId,
            IngredientName = detailModel.IngredientName,
            IngredientImageUrl = detailModel.IngredientImageUrl,
            Amount = detailModel.Amount,
            Unit = detailModel.Unit
        };

    public void MapToExistingDetailModel(IngredientAmountDetailModel existingDetailModel,
        IngredientListModel ingredient)
    {
        existingDetailModel.IngredientId = ingredient.Id;
        existingDetailModel.IngredientName = ingredient.Name;
        existingDetailModel.IngredientImageUrl = ingredient.ImageUrl;
    }

    public override IngredientAmountEntity MapToEntity(IngredientAmountDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");


    public IngredientAmountEntity MapToEntity(IngredientAmountDetailModel model, Guid recipeId)
        => new()
        {
            Id = model.Id,
            RecipeId = recipeId,
            IngredientId = model.IngredientId,
            Amount = model.Amount,
            Unit = model.Unit,
            Recipe = null!,
            Ingredient = null!
        };

    public IngredientAmountEntity MapToEntity(IngredientAmountListModel model, Guid recipeId)
        => new()
        {
            Id = model.Id,
            RecipeId = recipeId,
            IngredientId = model.IngredientId,
            Amount = model.Amount,
            Unit = model.Unit,
            Recipe = null!,
            Ingredient = null!
        };
}
