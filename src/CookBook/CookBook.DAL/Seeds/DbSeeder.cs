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

        bool hasLemon = dbContext.Set<IngredientEntity>().Any(i => i.Id == IngredientSeeds.Lemon.Id);
        bool hasWater = dbContext.Set<IngredientEntity>().Any(i => i.Id == IngredientSeeds.Water.Id);
        if (!hasLemon && !hasWater)
        {
            dbContext.SeedIngredients();
        }

        bool hasLemonadeRecipe = dbContext.Set<RecipeEntity>().Any(i => i.Id == RecipeSeeds.LemonadeRecipe.Id);
        if (!hasLemonadeRecipe)
        {
            dbContext.SeedRecipes();
        }

        bool hasLemonadeLemon = dbContext.Set<IngredientAmountEntity>().Any(i => i.Id == IngredientAmountSeeds.LemonadeLemon.Id);
        bool hasLemonadeWater = dbContext.Set<IngredientAmountEntity>().Any(i => i.Id == IngredientAmountSeeds.LemonadeWater.Id);
        if (!hasLemonadeLemon && !hasLemonadeWater)
        {
            dbContext.SeedIngredientAmounts();
        }

        dbContext.SaveChanges();
    }
}
