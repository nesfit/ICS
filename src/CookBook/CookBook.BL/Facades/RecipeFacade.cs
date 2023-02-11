using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.UnitOfWork;

namespace CookBook.BL.Facades;

public class RecipeFacade : FacadeBase<RecipeEntity, RecipeListModel, RecipeDetailModel, RecipeEntityMapper>,
    IRecipeFacade
{
    public RecipeFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        IRecipeModelMapper modelMapper)
        : base(unitOfWorkFactory, modelMapper)
    {
    }

    protected override string IncludesNavigationPathDetail =>
        $"{nameof(RecipeEntity.Ingredients)}.{nameof(IngredientAmountEntity.Ingredient)}";
}
