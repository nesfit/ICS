using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IngredientEntityMapper ingredientEntityMapper;
    private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;

    public UnitOfWorkFactory(
        IngredientEntityMapper ingredientEntityMapper,
        IDbContextFactory<CookBookDbContext> dbContextFactory)
    {
        this.ingredientEntityMapper = ingredientEntityMapper;
        _dbContextFactory = dbContextFactory;
    }

    public IUnitOfWork Create() => new UnitOfWork(ingredientEntityMapper, _dbContextFactory.CreateDbContext());
}