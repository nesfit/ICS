using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.BL.Models
{
    public record IngredientListModel : ModelBase
    {
        public string Name { get; set; }
    }
}
