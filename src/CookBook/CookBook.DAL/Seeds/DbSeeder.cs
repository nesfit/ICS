using CookBook.DAL.Options;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Seeds;

public class DbSeeder(IDbContextFactory<CookBookDbContext> dbContextFactory, DALOptions options)
    : IDbSeeder
{
    public void Seed()
    {
        using CookBookDbContext dbContext = dbContextFactory.CreateDbContext();

        if(options.SeedDemoData)
        {
            dbContext
                .SeedIngredients()
                .SeedRecipes()
                .SeedIngredientAmounts();
            dbContext.SaveChanges();
        }
    }
}
