using CookBook.Common.Enums;
using System;

namespace CookBook.DAL.Entities;

public record IngredientAmountEntity : IEntity
{
    public required Guid Id { get; set; }
    public required Guid RecipeId { get; set; }
    public required Guid IngredientId { get; set; }
    public double Amount { get; set; }
    public Unit Unit { get; set; }

    public RecipeEntity? Recipe { get; init; }

    public IngredientEntity? Ingredient { get; init; }
}
