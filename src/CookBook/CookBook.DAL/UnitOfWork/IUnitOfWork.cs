using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new();
    Task CommitAsync();
}