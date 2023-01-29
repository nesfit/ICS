namespace CookBook.App.Messages;

public record IngredientEditMessage
{
    public required Guid IngredientId { get; init; }
}