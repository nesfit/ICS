using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class RecipeFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    RecipeModelMapper modelMapper)
    : FacadeBase<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper>(unitOfWorkFactory, modelMapper),
        IRecipeFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] {$"{nameof(RecipeEntity.Ingredients)}.{nameof(IngredientAmountEntity.Ingredient)}"};

    public async Task AddIngredientAsync(Guid recipeId, IngredientAmountListModel model)
    {
        IngredientAmountEntity entity = modelMapper.MapIngredientAmountToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        repository.Insert(entity);
        await uow.CommitAsync();
    }

    public async Task UpdateIngredientAsync(Guid recipeId, IngredientAmountListModel model)
    {
        IngredientAmountEntity entity = modelMapper.MapIngredientAmountToEntity(model, recipeId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        await repository.UpdateAsync(entity);
        await uow.CommitAsync();
    }

    public async Task RemoveIngredientAsync(Guid ingredientAmountId)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<IngredientAmountEntity> repository =
            uow.GetRepository<IngredientAmountEntity, IngredientAmountEntityMapper>();

        await repository.DeleteAsync(ingredientAmountId);
        await uow.CommitAsync();
    }
}
