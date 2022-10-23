using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientFacade : CRUDFacade<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper>
{
    public IngredientFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IModelMapper<IngredientEntity, IngredientListModel, IngredientDetailModel> modelMapper)
        : base(unitOfWorkFactory, modelMapper)
    {
    }
}