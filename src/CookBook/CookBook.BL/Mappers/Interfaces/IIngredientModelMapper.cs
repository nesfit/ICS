using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public interface IIngredientModelMapper : IModelMapper<IngredientEntity, IngredientListModel, IngredientDetailModel>
{
}