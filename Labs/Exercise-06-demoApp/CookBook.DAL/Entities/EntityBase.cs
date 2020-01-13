using System;
using CookBook.DAL.Interfaces;

namespace CookBook.DAL.Entities
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}