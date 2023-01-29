using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public class IngredientAmountFacade : FacadeBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel, IngredientAmountEntityMapper>, IIngredientAmountFacade
{
    private readonly IIngredientAmountModelMapper ingredientAmountModelMapper;

    public IngredientAmountFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IIngredientAmountModelMapper ingredientAmountModelMapper)
        : base(unitOfWorkFactory, ingredientAmountModelMapper)
    {
        this.ingredientAmountModelMapper = ingredientAmountModelMapper;
    }

    public async Task SaveAsync(IngredientAmountListModel model, Guid recipeId)
    {
        var entity = ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        if (repository.Exists(entity))
        {
            repository.Update(entity);
            await uow.CommitAsync();
        }
    }

    public async Task<IngredientAmountDetailModel> SaveAsync(IngredientAmountDetailModel model, Guid recipeId)
    {
        var entity = ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        repository.Insert(entity);
        await uow.CommitAsync();

        return modelMapper.MapToDetailModel(entity);
    }
}