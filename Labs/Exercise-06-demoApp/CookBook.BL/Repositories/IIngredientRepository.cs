using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Repositories
{
    public interface IIngredientRepository : IRepository<IngredientEntity, IngredientListModel, IngredientDetailModel>
    {
    }
}
