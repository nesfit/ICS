using AutoMapper;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientFacade : CRUDFacade<IngredientEntity, IngredientListModel, IngredientDetailModel>
{
    public IngredientFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : base(unitOfWorkFactory, mapper)
    {
    }
}