using Nemesis.Essentials.Design;
using System;
using System.Collections.Generic;
using CookBook.Common.Enums;

namespace CookBook.DAL.Entities;

public record RecipeEntity(
    Guid Id, 
    string Name, 
    string Description, 
    TimeSpan Duration, 
    FoodType FoodType, 
    string? ImageUrl) : IEntity
{
    public ICollection<IngredientAmountEntity> Ingredients { get; init; } = new List<IngredientAmountEntity>();
}
