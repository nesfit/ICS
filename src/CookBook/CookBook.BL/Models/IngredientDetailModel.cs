namespace CookBook.BL.Models
{
    public record IngredientDetailModel : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}