using System;
using CookBook.Common;

namespace CookBook.BL.Models
{
    public abstract class ModelBase : IId
    {
        public Guid Id { get; set; }
    }
}