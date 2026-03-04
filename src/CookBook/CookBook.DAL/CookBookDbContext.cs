using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL;

public class CookBookDbContext(DbContextOptions contextOptions) : DbContext(contextOptions)
{
    public DbSet<IngredientAmountEntity> IngredientAmountEntities => Set<IngredientAmountEntity>();
    public DbSet<RecipeEntity> Recipes => Set<RecipeEntity>();
    public DbSet<IngredientEntity> Ingredients => Set<IngredientEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookBookDbContext).Assembly);
    }
}
