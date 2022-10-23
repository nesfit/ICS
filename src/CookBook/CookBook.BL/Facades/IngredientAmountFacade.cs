using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CookBook.BL.Facades;

public class IngredientAmountFacade : Facade<IngredientAmountEntity, IngredientAmountListModel, IngredientAmountDetailModel, IngredientAmountEntityMapper>, IIngredientAmountFacade
{
    private readonly IngredientAmountModelMapper ingredientAmountModelMapper;

    public IngredientAmountFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IngredientAmountModelMapper ingredientAmountModelMapper)
        : base(unitOfWorkFactory, ingredientAmountModelMapper)
    {
        this.ingredientAmountModelMapper = ingredientAmountModelMapper;
    }

    public async Task<IngredientAmountDetailModel> SaveAsync(IngredientAmountDetailModel model, Guid recipeId)
    {
        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        var entity = ingredientAmountModelMapper.MapToEntity(model, recipeId);
        repository.Insert(entity);
        await uow.CommitAsync();

        return modelMapper.MapToDetailModel(entity);
    }
}