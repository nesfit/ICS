﻿namespace CookBook.BL.Models
{
    public record IngredientListModel : ModelBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
