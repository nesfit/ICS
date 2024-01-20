using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL;

public class CookBookDbContext(DbContextOptions contextOptions, bool seedDemoData = false) : DbContext(contextOptions)
{
    public DbSet<IngredientAmountEntity> IngredientAmountEntities => Set<IngredientAmountEntity>();
    public DbSet<RecipeEntity> Recipes => Set<RecipeEntity>();
    public DbSet<IngredientEntity> Ingredients => Set<IngredientEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RecipeEntity>()
            .HasMany(i => i.Ingredients)
            .WithOne(i => i.Recipe)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IngredientEntity>()
            .HasMany<IngredientAmountEntity>()
            .WithOne(i => i.Ingredient)
            .OnDelete(DeleteBehavior.Restrict);

        if (seedDemoData)
        {
            IngredientSeeds.Seed(modelBuilder);
            RecipeSeeds.Seed(modelBuilder);
            IngredientAmountSeeds.Seed(modelBuilder);
        }
    }
}
