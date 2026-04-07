using CookBook.DAL.Options;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookBook.DAL.Seeds;

public class DbSeeder(IDbContextFactory<CookBookDbContext> dbContextFactory, IOptions<DALOptions> options)
    : IDbSeeder
{
    public void Seed()
    {
        using CookBookDbContext dbContext = dbContextFactory.CreateDbContext();

        if(options.Value.SeedDemoData is false)
        {
            return;
        }

        if (!dbContext.Set<IngredientEntity>().Any(i => i.Id == IngredientSeeds.Lemon.Id))
        {
            dbContext.Set<IngredientEntity>().Add(IngredientSeeds.Lemon);
        }

        if (!dbContext.Set<IngredientEntity>().Any(i => i.Id == IngredientSeeds.Water.Id))
        {
            dbContext.Set<IngredientEntity>().Add(IngredientSeeds.Water);
        }

        foreach (var ingredient in new[]
        {
            IngredientSeeds.Tomato, IngredientSeeds.Onion, IngredientSeeds.Garlic,
            IngredientSeeds.OliveOil, IngredientSeeds.Salt, IngredientSeeds.GroundBeef,
            IngredientSeeds.Spaghetti, IngredientSeeds.ChickenBreast, IngredientSeeds.BellPepper,
            IngredientSeeds.SoySauce, IngredientSeeds.Banana, IngredientSeeds.Milk,
            IngredientSeeds.Honey, IngredientSeeds.Flour, IngredientSeeds.Egg,
            IngredientSeeds.Butter, IngredientSeeds.ChocolateChips, IngredientSeeds.Sugar,
            IngredientSeeds.Carrot, IngredientSeeds.Potato, IngredientSeeds.Beef,
            IngredientSeeds.CocoaPowder, IngredientSeeds.Bread,
        })
        {
            if (!dbContext.Set<IngredientEntity>().Any(i => i.Id == ingredient.Id))
            {
                dbContext.Set<IngredientEntity>().Add(ingredient);
            }
        }

        if (!dbContext.Set<RecipeEntity>().Any(i => i.Id == RecipeSeeds.LemonadeRecipe.Id))
        {
            dbContext.Set<RecipeEntity>().Add(
                RecipeSeeds.LemonadeRecipe with { Ingredients = new List<IngredientAmountEntity>() });
        }

        foreach (var recipe in new[]
        {
            RecipeSeeds.TomatoSoupRecipe, RecipeSeeds.SpaghettiBoLogneseRecipe,
            RecipeSeeds.ChickenStirFryRecipe, RecipeSeeds.BananaSmoothieRecipe,
            RecipeSeeds.ChocolateChipCookiesRecipe, RecipeSeeds.ScrambledEggsRecipe,
            RecipeSeeds.PancakesRecipe, RecipeSeeds.BeefStewRecipe,
            RecipeSeeds.HotChocolateRecipe, RecipeSeeds.GarlicBreadRecipe,
        })
        {
            if (!dbContext.Set<RecipeEntity>().Any(r => r.Id == recipe.Id))
            {
                dbContext.Set<RecipeEntity>().Add(
                    recipe with { Ingredients = new List<IngredientAmountEntity>() });
            }
        }

        if (!dbContext.Set<IngredientAmountEntity>().Any(i => i.Id == IngredientAmountSeeds.LemonadeLemon.Id))
        {
            dbContext.Set<IngredientAmountEntity>().Add(
                IngredientAmountSeeds.LemonadeLemon with { Recipe = null!, Ingredient = null! });
        }

        if (!dbContext.Set<IngredientAmountEntity>().Any(i => i.Id == IngredientAmountSeeds.LemonadeWater.Id))
        {
            dbContext.Set<IngredientAmountEntity>().Add(
                IngredientAmountSeeds.LemonadeWater with { Recipe = null!, Ingredient = null! });
        }

        foreach (var ia in new[]
        {
            IngredientAmountSeeds.TomatoSoupTomato, IngredientAmountSeeds.TomatoSoupOnion,
            IngredientAmountSeeds.TomatoSoupGarlic, IngredientAmountSeeds.TomatoSoupOliveOil,
            IngredientAmountSeeds.TomatoSoupSalt,
            IngredientAmountSeeds.SpagBolGroundBeef, IngredientAmountSeeds.SpagBolSpaghetti,
            IngredientAmountSeeds.SpagBolTomato, IngredientAmountSeeds.SpagBolOnion,
            IngredientAmountSeeds.SpagBolGarlic, IngredientAmountSeeds.SpagBolOliveOil,
            IngredientAmountSeeds.StirFryChickenBreast, IngredientAmountSeeds.StirFryBellPepper,
            IngredientAmountSeeds.StirFryOnion, IngredientAmountSeeds.StirFrySoySauce,
            IngredientAmountSeeds.StirFryGarlic,
            IngredientAmountSeeds.SmoothieBanana, IngredientAmountSeeds.SmoothieMilk,
            IngredientAmountSeeds.SmoothieHoney,
            IngredientAmountSeeds.CookiesFlour, IngredientAmountSeeds.CookiesButter,
            IngredientAmountSeeds.CookiesSugar, IngredientAmountSeeds.CookiesEgg,
            IngredientAmountSeeds.CookiesChocolateChips,
            IngredientAmountSeeds.ScrambledEggsEgg, IngredientAmountSeeds.ScrambledEggsButter,
            IngredientAmountSeeds.ScrambledEggsMilk, IngredientAmountSeeds.ScrambledEggsSalt,
            IngredientAmountSeeds.PancakesFlour, IngredientAmountSeeds.PancakesEgg,
            IngredientAmountSeeds.PancakesMilk, IngredientAmountSeeds.PancakesButter,
            IngredientAmountSeeds.PancakesSugar,
            IngredientAmountSeeds.StewBeef, IngredientAmountSeeds.StewCarrot,
            IngredientAmountSeeds.StewPotato, IngredientAmountSeeds.StewOnion,
            IngredientAmountSeeds.StewGarlic,
            IngredientAmountSeeds.HotChocMilk, IngredientAmountSeeds.HotChocCocoaPowder,
            IngredientAmountSeeds.HotChocSugar, IngredientAmountSeeds.HotChocHoney,
            IngredientAmountSeeds.GarlicBreadBread, IngredientAmountSeeds.GarlicBreadButter,
            IngredientAmountSeeds.GarlicBreadGarlic,
        })
        {
            if (!dbContext.Set<IngredientAmountEntity>().Any(i => i.Id == ia.Id))
            {
                dbContext.Set<IngredientAmountEntity>().Add(
                    ia with { Recipe = null!, Ingredient = null! });
            }
        }

        dbContext.SaveChanges();
    }
}
