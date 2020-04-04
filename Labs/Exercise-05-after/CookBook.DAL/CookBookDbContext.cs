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

        public DbSet<IngredientAmountEntity> IngredientAmountEntities { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Using navigation properties
            modelBuilder.Entity<RecipeEntity>()
                .HasMany(i => i.Ingredients)
                .WithOne(c => c.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            //IngredientEntity does not have navigation properties
            modelBuilder.Entity<IngredientEntity>()
                .HasMany(typeof(IngredientAmountEntity)).WithOne(nameof(IngredientAmountEntity.Ingredient))
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
#endif
            base.OnConfiguring(optionsBuilder);
        }
    }
}   
