using System;

namespace School.DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}