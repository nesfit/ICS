using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IngredientEntityMapper ingredientEntityMapper;
    private readonly IngredientAmountEntityMapper ingredientAmountEntityMapper;
    private readonly RecipeEntityMapper recipeEntityMapper;
    private readonly DbContext dbContext;

    public UnitOfWork(
        IngredientEntityMapper ingredientEntityMapper,
        IngredientAmountEntityMapper ingredientAmountEntityMapper,
        RecipeEntityMapper recipeEntityMapper,
        DbContext dbContext)
    {
        this.ingredientEntityMapper = ingredientEntityMapper;
        this.ingredientAmountEntityMapper = ingredientAmountEntityMapper;
        this.recipeEntityMapper = recipeEntityMapper;
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
        => new Repository<TEntity>(dbContext);

    public IngredientRepository GetIngredientRepository()
        => new(ingredientEntityMapper, dbContext);

    public IngredientAmountRepository GetIngredientAmountRepository()
        => new(ingredientAmountEntityMapper, dbContext);

    public RecipeRepository GetRecipeRepository()
        => new(recipeEntityMapper, dbContext);

    public async Task CommitAsync() => await dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
}
