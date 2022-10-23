using CookBook.DAL.Entities;
using System;
using System.Linq;

namespace CookBook.DAL.UnitOfWork;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Get();
    void Delete(Guid entityId);
    bool Exists(TEntity entity);
    TEntity Insert(TEntity entity);
    TEntity Update(TEntity entity);
}