using System;
using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class RecipeSeeds
{
    public static readonly RecipeEntity RecipeEntity = new(
        Id: Guid.Parse(input: "fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Name: "Recipe seeded recipe 1",
        Description: "Recipe seeded recipe 1 description",
        Duration: TimeSpan.FromHours(value: 2),
        FoodType: FoodType.MainDish,
        ImageUrl: null);

    public static readonly RecipeEntity EmptyRecipeEntity = RecipeEntity with { Id = Guid.Parse("98B7F7B6-0F51-43B3-B8C0-B5FCFFF6DC2E") };
    

    static RecipeSeeds()
    {
        RecipeEntity.Ingredients = new[]
        {
            IngredientAmountSeeds.IngredientAmountEntity1,
            IngredientAmountSeeds.IngredientAmountEntity2
        };
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeEntity>().HasData(
            RecipeEntity with { Ingredients = Array.Empty<IngredientAmountEntity>() }
        );
    }
}