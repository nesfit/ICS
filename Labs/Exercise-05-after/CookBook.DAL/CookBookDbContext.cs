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
    }
}   
