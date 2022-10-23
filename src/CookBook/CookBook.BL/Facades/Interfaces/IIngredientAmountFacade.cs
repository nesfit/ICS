using CookBook.BL.Models;
using System;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public interface IIngredientAmountFacade
{
    Task DeleteAsync(Guid id);
    Task<IngredientAmountDetailModel> SaveAsync(IngredientAmountDetailModel model, Guid recipeId);
}