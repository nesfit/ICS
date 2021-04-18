namespace CookBook.BL.Models
{
    public record IngredientDetailModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}