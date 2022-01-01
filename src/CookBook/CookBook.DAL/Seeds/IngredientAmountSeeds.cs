using System;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class IngredientAmountSeeds
{
    public static IngredientAmountEntity IngredientAmountEntity1 = new(
        Id: Guid.Parse(input: "0d4fa150-ad80-4d46-a511-4c666166ec5e"),
        Amount: 1.0,
        Unit: Unit.Kg,
        RecipeId: RecipeSeeds.RecipeEntity.Id,
        IngredientId: IngredientSeeds.IngredientEntity1.Id)
    {
        Recipe = RecipeSeeds.RecipeEntity,
        Ingredient = IngredientSeeds.IngredientEntity1
    };

    public static IngredientAmountEntity IngredientAmountEntity2 = new(
        Id: Guid.Parse(input: "87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        Amount: 2.0,
        Unit: Unit.L,
        RecipeId: RecipeSeeds.RecipeEntity.Id,
        IngredientId: IngredientSeeds.IngredientEntity2.Id)
    {
        Recipe = RecipeSeeds.RecipeEntity,
        Ingredient = IngredientSeeds.IngredientEntity2
    };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IngredientAmountEntity>().HasData(
            IngredientAmountEntity1 with { Recipe = null, Ingredient = null },
            IngredientAmountEntity2 with { Recipe = null, Ingredient = null }
        );
    }
}