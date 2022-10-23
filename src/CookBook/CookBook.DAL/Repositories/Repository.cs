using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CookBook.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> dbSet;
    private readonly IEntityMapper<TEntity> entityMapper;

    public Repository(
        DbContext dbContext,
        IEntityMapper<TEntity> entityMapper)
    {
        dbSet = dbContext.Set<TEntity>();
        this.entityMapper = entityMapper;
    }

    public IQueryable<TEntity> Get() => dbSet;

    public bool Exists(TEntity entity)
        => dbSet.Any(e => e.Id == entity.Id);

    public TEntity Insert(TEntity entity)
        => dbSet.Add(entity).Entity;

    public TEntity Update(TEntity entity)
    {
        var existingEntity = dbSet.Single(e => e.Id == entity.Id);
        entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }

    public void Delete(Guid entityId) => dbSet.Remove(dbSet.Single(i => i.Id == entityId));
}