using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;

namespace CookBook.BL.Facades;

public interface IIngredientFacade : IFacade<IngredientEntity, IngredientListModel, IngredientDetailModel>
{
}