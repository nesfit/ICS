using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookBook.DAL.UnitOfWork;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly DbSet<TEntity> dbSet;
    private readonly IModel model;

    public Repository(DbContext dbContext)
    {
        dbSet = dbContext.Set<TEntity>();
        model = dbContext.Model;
    }

    public IQueryable<TEntity> Get() => dbSet;

    public bool Exists(TEntity entity)
        => dbSet.Any(e => e.Id == entity.Id);

    public TEntity Insert(TEntity entity)
        => dbSet.Add(entity).Entity;

    public async Task<TEntity> InsertOrUpdateAsync<TModel>(
        TModel model,
        IMapper mapper,
        CancellationToken cancellationToken = default)
        where TModel : class
    {
        //await dbSet.PreLoadChangeTracker(mapper.Map<TEntity>(model).Id, model, cancellationToken);

        // TODO: add proper implementation
        //return await dbSet.Persist(mapper).InsertOrUpdateAsync(model, cancellationToken);
        return null;
    }

    public void Delete(Guid entityId) => dbSet.Remove(dbSet.Single(i => i.Id == entityId));
}