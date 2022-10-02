using CookBook.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
    Task CommitAsync();
    IngredientRepository GetIngredientRepository();
}