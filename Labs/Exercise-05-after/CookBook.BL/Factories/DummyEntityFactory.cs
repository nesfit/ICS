using System;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Factories
{
    public class DummyEntityFactory : IEntityFactory 
    {
        public DummyEntityFactory()
        {
        }

        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new() => new TEntity();
    }
}
