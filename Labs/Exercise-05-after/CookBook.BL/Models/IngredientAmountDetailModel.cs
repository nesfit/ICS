using CookBook.DAL.Enums;
using System;

namespace CookBook.BL.Models
{
    public record IngredientAmountDetailModel : ModelBase
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; }
        public string IngredientDescription { get; set; }
        public string IngredientImageUrl { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }
    }
}