using System;
using System.Collections.Generic;
using System.Text;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Factories
{
    public class DummyEntityFactory<TEntity> : IEntityFactory<TEntity> where TEntity : class, IEntity, new()
    {
        public DummyEntityFactory()
        {
        }

        public TEntity Create(Guid id)=> new TEntity();

        public IEntityFactory<TTEntity> As<TTEntity>() where TTEntity : class, IEntity, new() => new DummyEntityFactory<TTEntity>();
    }
}
