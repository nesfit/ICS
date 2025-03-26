﻿using CookBook.DAL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookBook.DAL.Seeds;

public class DbSeeder(IDbContextFactory<CookBookDbContext> dbContextFactory, IOptions<DALOptions> options)
    : IDbSeeder
{
    public void Seed() => SeedAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await using CookBookDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        if(options.Value.SeedDemoData)
        {
            dbContext
                .SeedIngredients()
                .SeedRecipes()
                .SeedIngredientAmounts();
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
