using System;
using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public record IngredientEntity(Guid Id, string Name, string Description) : EntityBase(Id)
    {
        public IngredientEntity(string name, string description) : this(Guid.Empty, name, description) { }
    }
 
}
