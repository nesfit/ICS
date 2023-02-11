using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Facades;

public interface IRecipeFacade : IFacade<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
}
