using System;

namespace CookBook.DAL.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}