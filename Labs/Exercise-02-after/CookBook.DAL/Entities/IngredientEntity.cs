using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public record IngredientEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
