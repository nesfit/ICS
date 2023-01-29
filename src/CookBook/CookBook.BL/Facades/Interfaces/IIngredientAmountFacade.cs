using CookBook.BL.Models;
using System;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public interface IIngredientAmountFacade
{
    Task<IngredientAmountDetailModel> SaveAsync(IngredientAmountDetailModel model, Guid recipeId);
    Task SaveAsync(IngredientAmountListModel model, Guid recipeId);
    Task DeleteAsync(Guid id);
}