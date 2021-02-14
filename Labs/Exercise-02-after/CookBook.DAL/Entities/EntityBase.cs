using System;

namespace CookBook.DAL.Entities
{
    public abstract record EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}