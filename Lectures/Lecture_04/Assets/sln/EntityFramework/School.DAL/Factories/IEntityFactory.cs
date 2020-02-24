using System;
using School.DAL.Entities;

namespace School.DAL.Factories
{
    public interface IEntityFactory 
    {
        TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new();
    }
}