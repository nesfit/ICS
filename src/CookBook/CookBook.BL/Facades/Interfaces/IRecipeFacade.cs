using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Facades;

public interface IRecipeFacade : IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
    Task AddIngredientAsync(Guid recipeId, IngredientAmountListModel model);
    Task UpdateIngredientAsync(Guid recipeId, IngredientAmountListModel model);
    Task RemoveIngredientAsync(Guid ingredientAmountId);
}
