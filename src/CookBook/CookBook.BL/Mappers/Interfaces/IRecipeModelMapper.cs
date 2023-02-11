using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Mappers;

public interface IRecipeModelMapper : IModelMapper<RecipeEntity, RecipeListModel, RecipeDetailModel>
{
}
