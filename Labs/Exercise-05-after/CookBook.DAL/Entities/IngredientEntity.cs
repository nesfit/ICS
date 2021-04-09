using System;

namespace CookBook.DAL.Entities
{
    public record IngredientEntity(Guid Id, string Name, string Description, string ImageUrl) : EntityBase(Id)
    {
        public IngredientEntity(string name, string description, string imageUrl) : this(Guid.Empty, name, description, imageUrl) { }
        public IngredientEntity(Guid id) : this(id, string.Empty, string.Empty, string.Empty) { }
    }

}
