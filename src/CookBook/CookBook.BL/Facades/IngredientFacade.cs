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
    private readonly IngredientModelMapper ingredientModelMapper;

    public IngredientFacade(
        IngredientModelMapper ingredientModelMapper,
        IUnitOfWorkFactory unitOfWorkFactory,
        IMapper mapper)
        : base(unitOfWorkFactory, mapper)
    {
        this.ingredientModelMapper = ingredientModelMapper;
    }

    public override async Task<IngredientDetailModel?> GetAsync(Guid id)
    {
        var ingredient = await base.GetAsyncNew(id);
        return ingredientModelMapper.MapToDetailModel(ingredient);
    }

    public override async Task<IEnumerable<IngredientListModel>> GetAsync()
    {
        await using var uow = _unitOfWorkFactory.Create();
        var entities = uow
            .GetRepository<IngredientEntity>()
            .Get()
            .ToList();

        return ingredientModelMapper.MapToListModel(entities);
    }

    public override async Task<IngredientDetailModel> SaveAsync(IngredientDetailModel model)
    {
        IngredientDetailModel result;

        var entity = ingredientModelMapper.MapToEntity(model);

        var uow = _unitOfWorkFactory.Create();
        var repository = uow.GetIngredientRepository();

        if (repository.Exists(entity))
        {
            // TODO: Add updating of existing entity
            var updatedEntity = repository.Update(entity);
            result = ingredientModelMapper.MapToDetailModel(updatedEntity);
        }
        else
        {
            var insertedEntity = repository.Insert(entity);
            result = ingredientModelMapper.MapToDetailModel(insertedEntity);
        }

        await uow.CommitAsync();

        return result;
    }
}