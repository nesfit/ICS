using System;

namespace CookBook.DAL.Entities;

public record IngredientEntity(
    Guid Id,
    string Name,
    string Description,
    string? ImageUrl) : IEntity
{
}
