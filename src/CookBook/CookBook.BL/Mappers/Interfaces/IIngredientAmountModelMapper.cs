using CookBook.BL.Models;
using CookBook.DAL.Entities;
using System;

namespace CookBook.BL.Mappers;

public interface IIngredientAmountModelMapper : IModelMapper<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel>
{
    IngredientAmountListModel MapToListModel(IngredientAmountDetailModel detailModel);
    IngredientAmountEntity MapToEntity(IngredientAmountDetailModel model, Guid recipeId);
    void MapToExistingDetailModel(IngredientAmountDetailModel existingDetailModel, IngredientListModel ingredient);
    IngredientAmountEntity MapToEntity(IngredientAmountListModel model, Guid recipeId);
}