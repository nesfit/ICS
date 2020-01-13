using System;
using System.Linq;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CookBook.DAL.Factories
{
    public class EntityFactory<TEntity> : IEntityFactory<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly ChangeTracker _changeTracker;

        internal EntityFactory()
        {
        }

        public EntityFactory(ChangeTracker changeTracker) => _changeTracker = changeTracker;

        public TEntity Create(Guid id)
        {
            TEntity entity = null;
            if(id != Guid.Empty)
            {
                entity = _changeTracker?.Entries<TEntity>().SingleOrDefault(i => i.Entity.Id == id)
                    ?.Entity;
                if (entity == null)
                {
                    entity = new TEntity {Id = id};
                    _changeTracker?.Context.Attach(entity);
                }
            }
            else
            {
                entity = new TEntity();
            }
            return entity;
        }

        public IEntityFactory<TTEntity> As<TTEntity>() where TTEntity : class, IEntity, new() => new EntityFactory<TTEntity>(_changeTracker); 
    }
}