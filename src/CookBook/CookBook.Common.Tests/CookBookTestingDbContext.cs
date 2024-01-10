using CookBook.Common.Tests.Seeds;
using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests;

public class CookBookTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
    : CookBookDbContext(contextOptions, seedDemoData: false)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            IngredientSeeds.Seed(modelBuilder);
            RecipeSeeds.Seed(modelBuilder);
            IngredientAmountSeeds.Seed(modelBuilder);
        }
    }
}
