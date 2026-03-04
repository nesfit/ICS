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

        if (!dbContext.Set<RecipeEntity>().Any(i => i.Id == RecipeSeeds.LemonadeRecipe.Id))
        {
            dbContext.Set<RecipeEntity>().Add(
                RecipeSeeds.LemonadeRecipe with { Ingredients = new List<IngredientAmountEntity>() });
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

        dbContext.SaveChanges();
    }
}
