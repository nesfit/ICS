using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class RecipeFacade : CRUDFacade<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper>
{
    public RecipeFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IModelMapper<RecipeEntity, RecipeListModel, RecipeDetailModel> modelMapper)
        : base(unitOfWorkFactory, modelMapper)
    {
    }
}