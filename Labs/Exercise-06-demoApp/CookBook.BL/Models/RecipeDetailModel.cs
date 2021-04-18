using CookBook.DAL.Enums;
using System;
using System.Collections.Generic;
using Nemesis.Essentials.Design;

namespace CookBook.BL.Models
{
    public record RecipeDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<IngredientAmountDetailModel> Ingredients { get; set; } = new  ValueCollection<IngredientAmountDetailModel>();
    }
}