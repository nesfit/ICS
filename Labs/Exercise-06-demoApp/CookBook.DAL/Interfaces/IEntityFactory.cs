using System;
using CookBook.DAL.Factories;

namespace CookBook.DAL.Interfaces
{
    public interface IEntityFactory<out TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Create(Guid id);
        IEntityFactory<TTEntity> As<TTEntity>() where TTEntity : class, IEntity, new();
    }
}