using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DbContext dbContext;

    public UnitOfWork(DbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new()
        => new Repository<TEntity>(dbContext, new TEntityMapper());

    public async Task CommitAsync() => await dbContext.SaveChangesAsync();

    public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();
}
