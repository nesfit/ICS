using System;
using System.Collections.Generic;

namespace CookBook.BL.Models
{
    public record IngredientDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}