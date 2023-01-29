namespace CookBook.App.Messages;

public record RecipeEditMessage
{
    public required Guid RecipeId { get; init; }
}