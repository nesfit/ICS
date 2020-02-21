using System;
using System.Collections.Generic;
using System.Text;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Factories
{
    public class CreateNewEntityFactory : IEntityFactory 
    {
        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new() => new TEntity();
    }
}
