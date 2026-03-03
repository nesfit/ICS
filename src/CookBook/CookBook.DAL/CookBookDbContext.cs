using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
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

        modelBuilder.Entity<RecipeEntity>()
            .Property(i => i.Name)
            .HasMaxLength(200);

        modelBuilder.Entity<RecipeEntity>()
            .Property(i => i.Description)
            .HasMaxLength(2_000);

        modelBuilder.Entity<RecipeEntity>()
            .Property(i => i.ImageUrl)
            .HasMaxLength(2_048);

        modelBuilder.Entity<IngredientEntity>()
            .Property(i => i.Name)
            .HasMaxLength(200);

        modelBuilder.Entity<IngredientEntity>()
            .Property(i => i.Description)
            .HasMaxLength(2_000);

        modelBuilder.Entity<IngredientEntity>()
            .Property(i => i.ImageUrl)
            .HasMaxLength(2_048);

        modelBuilder.Entity<IngredientAmountEntity>()
            .HasIndex(i => new { i.RecipeId, i.IngredientId })
            .IsUnique();

        modelBuilder.Entity<IngredientAmountEntity>()
            .Property(i => i.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<RecipeEntity>()
            .HasMany(i => i.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IngredientEntity>()
            .HasMany<IngredientAmountEntity>()
            .WithOne(i => i.Ingredient)
            .HasForeignKey(i => i.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
