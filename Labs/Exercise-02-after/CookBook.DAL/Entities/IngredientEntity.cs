using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public record IngredientEntity : EntityBase
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
