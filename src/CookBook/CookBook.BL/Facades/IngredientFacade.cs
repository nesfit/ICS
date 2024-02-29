using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IngredientModelMapper modelMapper)
    :
        FacadeBase<IngredientEntity, IngredientListModel, IngredientDetailModel, IngredientEntityMapper>(
            unitOfWorkFactory, modelMapper), IIngredientFacade;
