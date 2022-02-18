using System;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class IngredientAmountSeeds
{
    public static readonly IngredientAmountEntity LemonadeLemon = new(
        Id: Guid.Parse(input: "0d4fa150-ad80-4d46-a511-4c666166ec5e"),
        Amount: 250,
        Unit: Unit.Ml,
        RecipeId: RecipeSeeds.LemonadeRecipe.Id,
        IngredientId: IngredientSeeds.Lemon.Id)
    {
        Recipe = RecipeSeeds.LemonadeRecipe,
        Ingredient = IngredientSeeds.Lemon
    };

    public static readonly IngredientAmountEntity LemonadeWater = new(
        Id: Guid.Parse(input: "87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        Amount: 2.0,
        Unit: Unit.L,
        RecipeId: RecipeSeeds.LemonadeRecipe.Id,
        IngredientId: IngredientSeeds.Water.Id)
    {
        Recipe = RecipeSeeds.LemonadeRecipe,
        Ingredient = IngredientSeeds.Water
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IngredientAmountEntity>().HasData(
            LemonadeLemon with { Recipe = null, Ingredient = null },
            LemonadeWater with { Recipe = null, Ingredient = null }
        );
    }
}