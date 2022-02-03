using System;

namespace CookBook.DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}