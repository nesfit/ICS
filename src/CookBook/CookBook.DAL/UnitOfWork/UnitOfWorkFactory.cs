using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IngredientEntityMapper ingredientEntityMapper;
    private readonly IngredientAmountEntityMapper ingredientAmountEntityMapper;
    private readonly RecipeEntityMapper recipeEntityMapper;
    private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;

    public UnitOfWorkFactory(
        IngredientEntityMapper ingredientEntityMapper,
        IngredientAmountEntityMapper ingredientAmountEntityMapper,
        RecipeEntityMapper recipeEntityMapper,
        IDbContextFactory<CookBookDbContext> dbContextFactory)
    {
        this.ingredientEntityMapper = ingredientEntityMapper;
        this.ingredientAmountEntityMapper = ingredientAmountEntityMapper;
        this.recipeEntityMapper = recipeEntityMapper;
        _dbContextFactory = dbContextFactory;
    }

    public IUnitOfWork Create() => new UnitOfWork(ingredientEntityMapper, ingredientAmountEntityMapper, recipeEntityMapper, _dbContextFactory.CreateDbContext());
}