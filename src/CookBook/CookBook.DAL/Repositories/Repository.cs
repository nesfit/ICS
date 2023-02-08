using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CookBook.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly IEntityMapper<TEntity> _entityMapper;

    public Repository(
        DbContext dbContext,
        IEntityMapper<TEntity> entityMapper)
    {
        _dbSet = dbContext.Set<TEntity>();
        this._entityMapper = entityMapper;
    }

    public IQueryable<TEntity> Get() => _dbSet;

    public bool Exists(TEntity entity)
        => entity.Id != Guid.Empty 
           && _dbSet.Any(e => e.Id == entity.Id);

    public TEntity Insert(TEntity entity)
        => _dbSet.Add(entity).Entity;

    public TEntity Update(TEntity entity)
    {
        var existingEntity = _dbSet.Single(e => e.Id == entity.Id);
        _entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }

    public void Delete(Guid entityId) => _dbSet.Remove(_dbSet.Single(i => i.Id == entityId));
}