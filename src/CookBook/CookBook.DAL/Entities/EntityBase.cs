using System;

namespace CookBook.DAL.Entities;

public abstract record EntityBase(Guid Id) : IEntity
{
    protected EntityBase(): this(Id: Guid.Empty) { }
}