using System;
using System.Collections.Generic;
using CookBook.Common.Enums;

namespace CookBook.DAL.Entities;

public record IngredientAmountEntity(
    Guid Id,
    double Amount,
    Unit Unit,
    Guid RecipeId,
    Guid IngredientId) : EntityBase(Id: Id)
{
    //TODO remove after repository refactoring
#nullable disable
    public IngredientAmountEntity() : this(default, default, default, default, default) { }
#nullable enable

    public RecipeEntity? Recipe { get; init; }

    public IngredientEntity? Ingredient { get; init; }

    private sealed class IngredientAmountWithoutRecipeEntityEqualityComparer : IEqualityComparer<IngredientAmountEntity>
    {
        public bool Equals(IngredientAmountEntity? x, IngredientAmountEntity? y)
        {
            if (ReferenceEquals(objA: x, objB: y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Amount.Equals(obj: y.Amount) 
                   && x.Unit == y.Unit 
                   && x.RecipeId.Equals(g: y.RecipeId) 
                   && x.IngredientId.Equals(g: y.IngredientId) 
                   && Equals(objA: x.Ingredient, objB: y.Ingredient);
        }

        public int GetHashCode(IngredientAmountEntity obj) 
            => HashCode.Combine(value1: obj.Amount, value2: (int) obj.Unit, value3: obj.RecipeId, value4: obj.IngredientId, value5: obj.Ingredient);
    }

    public static IEqualityComparer<IngredientAmountEntity> IngredientAmountWithoutRecipeEntityComparer { get; } 
        = new IngredientAmountWithoutRecipeEntityEqualityComparer();
}