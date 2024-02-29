using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class IngredientAmountFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    IngredientAmountModelMapper ingredientAmountModelMapper)
    :
        FacadeBase<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel,
            IngredientAmountEntityMapper>(unitOfWorkFactory, ingredientAmountModelMapper), IIngredientAmountFacade
{
    public async Task SaveAsync(IngredientAmountListModel model, Guid recipeId)
    {
        IngredientAmountEntity entity = ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }

    public async Task SaveAsync(IngredientAmountDetailModel model, Guid recipeId)
    {
        IngredientAmountEntity entity = ingredientAmountModelMapper.MapToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        repository.Insert(entity);
        await uow.CommitAsync();
    }
}
