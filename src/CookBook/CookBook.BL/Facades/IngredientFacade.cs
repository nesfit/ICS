using AutoMapper;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public class IngredientFacade : CRUDFacade<IngredientEntity, IngredientListModel, IngredientDetailModel>
{
    private readonly IngredientMapper ingredientMapper;

    public IngredientFacade(
        IngredientMapper ingredientMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IMapper mapper)
        : base(unitOfWorkFactory, mapper)
    {
        this.ingredientMapper = ingredientMapper;
    }

    public override async Task<IngredientDetailModel?> GetAsync(Guid id)
    {
        var ingredient = await base.GetAsyncNew(id);
        return ingredientMapper.MapToDetailModel(ingredient);
    }

    public override async Task<IEnumerable<IngredientListModel>> GetAsync()
    {
        await using var uow = _unitOfWorkFactory.Create();
        var query = uow
            .GetRepository<IngredientEntity>()
            .Get()
            .ToList();

        return ingredientMapper.MapToListModel(query);
    }
}