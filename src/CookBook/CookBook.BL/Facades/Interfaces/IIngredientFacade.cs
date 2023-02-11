using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Facades;

public interface IIngredientFacade : IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel>
{
}
