using System;
using System.Collections.Generic;
using CookBook.Common.Enums;

namespace CookBook.DAL.Entities;

public record IngredientAmountEntity(
    Guid Id,
    double Amount,
    Unit Unit,
    Guid RecipeId,
    Guid IngredientId) : IEntity
{
    //Automapper requires parameter less constructor for collection synchronization for now
#nullable disable
    public IngredientAmountEntity() : this(default, default, default, default, default) { }
#nullable enable
    
    public RecipeEntity? Recipe { get; init; }

    public IngredientEntity? Ingredient { get; init; }
}
