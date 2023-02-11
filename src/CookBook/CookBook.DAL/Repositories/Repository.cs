using System;
using System.Linq;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;

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
        _entityMapper = entityMapper;
    }

    public IQueryable<TEntity> Get() => _dbSet;

    public async ValueTask<bool> ExistsAsync(TEntity entity)
        => entity.Id != Guid.Empty && await _dbSet.AnyAsync(e => e.Id == entity.Id);

    public async Task<TEntity> InsertAsync(TEntity entity)
        => (await _dbSet.AddAsync(entity)).Entity;

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id);
        _entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }

    public void Delete(Guid entityId) => _dbSet.Remove(_dbSet.Single(i => i.Id == entityId));
}
