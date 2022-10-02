using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly IngredientEntityMapper ingredientEntityMapper;
    private readonly DbContext dbContext;

    public UnitOfWork(
        IngredientEntityMapper ingredientEntityMapper,
        DbContext dbContext)
    {
        this.ingredientEntityMapper = ingredientEntityMapper;
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class, IEntity
        => new Repository<TEntity>(dbContext);

    public IngredientRepository GetIngredientRepository()
        => new(ingredientEntityMapper, dbContext);

    public async Task CommitAsync() => await dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
}
