using CookBook.BL.Models;

namespace CookBook.BL.Facades;

public interface IIngredientAmountFacade
{
    Task SaveAsync(IngredientAmountDetailModel model, Guid recipeId);
    Task SaveAsync(IngredientAmountListModel model, Guid recipeId);
    Task DeleteAsync(Guid id);
}
