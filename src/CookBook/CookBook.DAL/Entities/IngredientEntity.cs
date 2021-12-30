namespace CookBook.DAL.Entities
{
    public record IngredientEntity : EntityBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string?ImageUrl { get; set; }
    }
}
