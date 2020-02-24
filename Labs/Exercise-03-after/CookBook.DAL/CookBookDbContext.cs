using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>()
                .HasMany<IngredientAmountEntity>(i => i.Ingredients)
                .WithOne(i => i.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IngredientEntity>()
                .HasMany<IngredientAmountEntity>()
                .WithOne(i => i.Ingredient)
                .OnDelete(DeleteBehavior.Restrict);

            IngredientSeeds.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
