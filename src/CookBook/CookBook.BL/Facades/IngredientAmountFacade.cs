using System;
using System.Threading.Tasks;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientAmountFacade :
    FacadeBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel,
        IngredientAmountEntityMapper>, IIngredientAmountFacade
{
    private readonly IIngredientAmountModelMapper _ingredientAmountModelMapper;

    public IngredientAmountFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IIngredientAmountModelMapper ingredientAmountModelMapper)
        : base(unitOfWorkFactory, ingredientAmountModelMapper) =>
        _ingredientAmountModelMapper = ingredientAmountModelMapper;

    public async Task SaveAsync(IngredientAmountListModel model, Guid recipeId)
    {
        IngredientAmountEntity entity = _ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }

    public async Task<IngredientAmountDetailModel> SaveAsync(IngredientAmountDetailModel model, Guid recipeId)
    {
        IngredientAmountEntity entity = _ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        await repository.InsertAsync(entity);
        await uow.CommitAsync();

        return ModelMapper.MapToDetailModel(entity);
    }
}
