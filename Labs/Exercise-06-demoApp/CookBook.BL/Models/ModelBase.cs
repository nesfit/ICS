using System;

namespace CookBook.BL.Models
{
    public abstract record ModelBase : IModel
    {
        public Guid Id { get; set; }
    }
}