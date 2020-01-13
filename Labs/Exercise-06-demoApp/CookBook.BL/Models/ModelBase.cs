using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CookBook.BL.Interfaces;
using CookBook.Common;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Models
{
    public abstract class ModelBase : IId
    {
        public Guid Id { get; set; }
    }
}