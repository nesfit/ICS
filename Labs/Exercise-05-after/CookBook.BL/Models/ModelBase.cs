using System;

namespace CookBook.BL.Models
{
    public abstract record ModelBase
    {
        public Guid Id { get; set; }
    }
}