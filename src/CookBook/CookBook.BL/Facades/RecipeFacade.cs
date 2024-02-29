using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
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
}
