using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext()
        {

        }
        public CookBookDbContext(DbContextOptions<CookBookDbContext> contextOptions)
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
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = MigrationDb;MultipleActiveResultSets = True;Integrated Security = True; ");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}   
