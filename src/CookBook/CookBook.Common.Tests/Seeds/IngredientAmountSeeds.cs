using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests.Seeds;

public static class IngredientAmountSeeds
{
    public static readonly IngredientAmountEntity EmptyIngredientAmountEntity = new()
    {
        Id = default,
        RecipeId = default,
        IngredientId = default,
        Amount = default,
        Unit = default,
        Recipe = default!,
        Ingredient = default!,
    };

    public static readonly IngredientAmountEntity IngredientAmountEntity1 = new()
    {
        Id = Guid.Parse(input: "0d4fa150-ad80-4d46-a511-4c666166ec5e"),
        RecipeId = RecipeSeeds.RecipeEntity.Id,
        IngredientId = IngredientSeeds.IngredientEntity1.Id,
        Amount = 1.0,
        Unit = Unit.Kg,
        Recipe = RecipeSeeds.RecipeEntity,
        Ingredient = IngredientSeeds.IngredientEntity1,
    };

    public static readonly IngredientAmountEntity IngredientAmountEntity2 = new()
    {
        Id = Guid.Parse(input: "87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        RecipeId = RecipeSeeds.RecipeEntity.Id,
        IngredientId = IngredientSeeds.IngredientEntity2.Id,
        Amount = 2.0,
        Unit = Unit.L,
        Recipe = RecipeSeeds.RecipeEntity,
        Ingredient = IngredientSeeds.IngredientEntity2,
    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly IngredientAmountEntity IngredientAmountEntityUpdate = IngredientAmountEntity1 with { Id = Guid.Parse("A2E6849D-A158-4436-980C-7FC26B60C674"), Ingredient = null!, Recipe = null!, RecipeId = RecipeSeeds.RecipeForIngredientAmountEntityUpdate.Id};
    public static readonly IngredientAmountEntity IngredientAmountEntityDelete = IngredientAmountEntity1 with { Id = Guid.Parse("30872EFF-CED4-4F2B-89DB-0EE83A74D279"), Ingredient = null!, Recipe = null!, RecipeId = RecipeSeeds.RecipeForIngredientAmountEntityDelete.Id };

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IngredientAmountEntity>().HasData(
            IngredientAmountEntity1 with { Recipe = null!, Ingredient = null! },
            IngredientAmountEntity2 with { Recipe = null!, Ingredient = null! },
            IngredientAmountEntityUpdate,
            IngredientAmountEntityDelete
        );
    }
}
