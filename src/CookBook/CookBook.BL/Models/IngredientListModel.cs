namespace CookBook.BL.Models
{
    public record IngredientListModel : ModelBase
    {
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
