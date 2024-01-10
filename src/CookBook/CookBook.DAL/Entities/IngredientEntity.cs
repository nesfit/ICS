namespace CookBook.DAL.Entities;

public record IngredientEntity : IEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? ImageUrl { get; set; }
    public required Guid Id { get; set; }
}
