using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientFacade : FacadeBase<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper>, IIngredientFacade
{
    public IngredientFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IIngredientModelMapper modelMapper)
        : base(unitOfWorkFactory, modelMapper)
    {
    }
}