using CookBook.Common.Enums;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public static class RecipeSeeds
{
    public static readonly RecipeEntity LemonadeRecipe = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Name = "Lemonade",
        Description = "Sweet summer lemonade",
        Duration = TimeSpan.FromMinutes(2.5),
        FoodType = FoodType.Drink,
        ImageUrl =
            @"https://www.thespruceeats.com/thmb/bOkzNHNuzGEH2UUAbmFBtTwAy6M=/2539x2539/smart/filters:no_upscale()/homemade-lemonade-2216227-hero-02copy-767d28c1e7cf468db2282d77103d0bf4.jpg"
    };

    static RecipeSeeds()
    {
        LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeLemon);
        LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeWater);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<RecipeEntity>().HasData(
            LemonadeRecipe with { Ingredients = Array.Empty<IngredientAmountEntity>() }
        );
}
