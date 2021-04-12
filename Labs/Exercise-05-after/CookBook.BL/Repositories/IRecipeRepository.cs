using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Repositories
{
    public interface IRecipeRepository : IRepository<RecipeEntity, RecipeListModel, RecipeDetailModel>
    {
    }
}