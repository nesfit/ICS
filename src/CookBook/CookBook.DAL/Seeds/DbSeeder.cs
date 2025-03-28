using CookBook.DAL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookBook.DAL.Seeds;

public class DbSeeder(IDbContextFactory<CookBookDbContext> dbContextFactory, IOptions<DALOptions> options)
    : IDbSeeder
{
    public void Seed()
    {
        using CookBookDbContext dbContext = dbContextFactory.CreateDbContext();

        if(options.Value.SeedDemoData)
        {
            dbContext
                .SeedIngredients()
                .SeedRecipes()
                .SeedIngredientAmounts();
            dbContext.SaveChanges();
        }
    }
}
