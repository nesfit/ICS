using System;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds
{
    public static class IngredientAmountSeeds
    {
        public static IngredientAmountEntity IngredientAmountEntity1 = new()
        {
            Id = Guid.Parse("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
            Amount = 1.0,
            Unit = Unit.Kg,
            Recipe = RecipeSeeds.RecipeEntity,
            RecipeId = RecipeSeeds.RecipeEntity.Id,
            Ingredient = IngredientSeeds.IngredientEntity1,
            IngredientId = IngredientSeeds.IngredientEntity1.Id
        };

        public static IngredientAmountEntity IngredientAmountEntity2 = new()
        {
            Id = Guid.Parse("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
            Amount = 2.0,
            Unit = Unit.L,
            Recipe = RecipeSeeds.RecipeEntity,
            RecipeId = RecipeSeeds.RecipeEntity.Id,
            Ingredient = IngredientSeeds.IngredientEntity2,
            IngredientId = IngredientSeeds.IngredientEntity2.Id
        };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientAmountEntity>().HasData(
                new
                {
                    IngredientAmountEntity1.Id,
                    IngredientAmountEntity1.Amount,
                    IngredientAmountEntity1.Unit,
                    IngredientId = IngredientAmountEntity1.IngredientId,
                    RecipeId = IngredientAmountEntity1.RecipeId
                },
                new
                {
                    IngredientAmountEntity2.Id,
                    IngredientAmountEntity2.Amount,
                    IngredientAmountEntity2.Unit,
                    IngredientId = IngredientAmountEntity2.IngredientId,
                    RecipeId = IngredientAmountEntity2.RecipeId
                }
            );
        }
    }
}