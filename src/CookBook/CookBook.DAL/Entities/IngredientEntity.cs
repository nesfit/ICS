using System;

namespace CookBook.DAL.Entities;

public record IngredientEntity(
    Guid Id,
    string Name,
    string Description,
    string? ImageUrl) : EntityBase(Id)
{
//TODO remove after repository refactoring
#nullable disable
    public IngredientEntity() : this(default, default, default, default)
    {
    }
}