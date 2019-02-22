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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Data Source=(LocalDB)\MSSQLLocalDB;
        //        Initial Catalog = CookBook;
        //        MultipleActiveResultSets = True;
        //        Integrated Security = True; ");
        //}

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
    }
}
