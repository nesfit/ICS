using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests.Seeds;

public static class RecipeSeeds
{
    public static readonly RecipeEntity EmptyRecipeEntity = new()
    {
        Id = default, 
        Name = default!,
        Description = default!,
        Duration = default,
        FoodType = default,
        ImageUrl = default,
    };
    
    public static readonly RecipeEntity RecipeEntity = new()
    {
        Id = Guid.Parse(input: "fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Name = "Recipe seeded recipe 1",
        Description = "Recipe seeded recipe 1 description",
        Duration = TimeSpan.FromHours(value: 2),
        FoodType = FoodType.MainDish,
        ImageUrl = null,
    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly RecipeEntity RecipeEntityWithNoIngredients = RecipeEntity with { Id = Guid.Parse("98B7F7B6-0F51-43B3-B8C0-B5FCFFF6DC2E"), Ingredients = Array.Empty<IngredientAmountEntity>() };
    public static readonly RecipeEntity RecipeEntityUpdate = RecipeEntity with { Id = Guid.Parse("0953F3CE-7B1A-48C1-9796-D2BAC7F67868"), Ingredients = Array.Empty<IngredientAmountEntity>() };
    public static readonly RecipeEntity RecipeEntityDelete = RecipeEntity with { Id = Guid.Parse("5DCA4CEA-B8A8-4C86-A0B3-FFB78FBA1A09"), Ingredients = Array.Empty<IngredientAmountEntity>() };

    public static readonly RecipeEntity RecipeForIngredientAmountEntityUpdate = RecipeEntity with { Id = Guid.Parse("4FD824C0-A7D1-48BA-8E7C-4F136CF8BF31"), Ingredients = Array.Empty<IngredientAmountEntity>() };
    public static readonly RecipeEntity RecipeForIngredientAmountEntityDelete = RecipeEntity with { Id = Guid.Parse("F78ED923-E094-4016-9045-3F5BB7F2EB88"), Ingredients = new List<IngredientAmountEntity>() };


    static RecipeSeeds()
    {
        RecipeEntity.Ingredients.Add(IngredientAmountSeeds.IngredientAmountEntity1);
        RecipeEntity.Ingredients.Add(IngredientAmountSeeds.IngredientAmountEntity2);
        
        RecipeForIngredientAmountEntityDelete.Ingredients.Add(IngredientAmountSeeds.IngredientAmountEntityDelete);
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeEntity>().HasData(
            RecipeEntity with { Ingredients = Array.Empty<IngredientAmountEntity>() },
            RecipeEntityWithNoIngredients,
            RecipeEntityUpdate,
            RecipeEntityDelete,
            RecipeForIngredientAmountEntityUpdate,
            RecipeForIngredientAmountEntityDelete with { Ingredients = Array.Empty<IngredientAmountEntity>() }
        );
    }
}