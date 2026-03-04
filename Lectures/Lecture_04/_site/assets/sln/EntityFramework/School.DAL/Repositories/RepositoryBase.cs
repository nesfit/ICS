using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using School.DAL.Entities;

namespace School.DAL.Repositories;

public class RepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
{
    private readonly UnitOfWork.UnitOfWork _unitOfWork;

    public RepositoryBase(UnitOfWork.UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public void Delete(TEntity entity)
    {
        _unitOfWork.DbContext.Set<TEntity>()
            .Remove(entity);
    }

    public void DeleteById(Guid entityId)
    {
        var entity = new TEntity {Id = entityId};
        Delete(entity);
    }

    public TEntity? GetById(Guid entityId)
    {
        return _unitOfWork.DbContext
            .Set<TEntity>()
            .SingleOrDefault(entity => entity.Id.Equals(entityId));
    }

    public TEntity InsertOrUpdate(TEntity entity)
    {
        var exists = _unitOfWork.DbContext
            .Set<TEntity>()
            .AsNoTracking()
            .Any(e => e.Id == entity.Id);

        if (exists)
        {
            _unitOfWork.DbContext.Update(entity);
            SynchronizeCollections(entity);
        }
        else
        {
            _unitOfWork.DbContext.Add(entity);
        }

#if DEBUG
        DisplayStates(_unitOfWork.DbContext.ChangeTracker.Entries());
#endif
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _unitOfWork.DbContext
            .Set<TEntity>();
    }

    //TODO this code will be updated in following lectures
    private void SynchronizeCollections(TEntity entity)
    {
        var collectionsToBeSynchronized = typeof(TEntity).GetProperties().Where(i =>
            i.PropertyType.IsGenericType && i.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

        var toBeSynchronized = collectionsToBeSynchronized as PropertyInfo[]
                               ?? collectionsToBeSynchronized.ToArray();
        if (!toBeSynchronized.Any())
        {
            return;
        }

        IQueryable<TEntity> query = _unitOfWork.DbContext
            .Set<TEntity>()
            .AsNoTracking();

        foreach (var collectionSelector in toBeSynchronized)
        {
            query = query.Include(collectionSelector.Name);
        }

        var entityInDb = query.SingleOrDefault(i => i.Id == entity.Id);
        if (entityInDb is null) return;

        foreach (var collectionSelector in toBeSynchronized)
        {
            var updatedCollection = (collectionSelector.GetValue(entity) as IEnumerable)
                ?.Cast<IEntity>()
                .ToArray() ?? Array.Empty<IEntity>();
            var collectionInDb = (collectionSelector.GetValue(entityInDb) as IEnumerable)
                ?.Cast<IEntity>()
                .ToArray() ?? Array.Empty<IEntity>();

            foreach (var item in collectionInDb)
            {
                if (!updatedCollection.Contains(item, PrimaryKeyComparers.IdComparer))
                {
                    // Delete by key-only stub to avoid attaching a graph that may conflict with
                    // already tracked principal entities with the same key.
                    if (Activator.CreateInstance(item.GetType()) is IEntity entityToDelete)
                    {
                        entityToDelete.Id = item.Id;
                        _unitOfWork.DbContext.Entry(entityToDelete).State = EntityState.Deleted;
                    }
                }
            }
        }
    }

    private static void DisplayStates(IEnumerable<EntityEntry> entries)
    {
        foreach (var entry in entries)
            Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
    }
}
