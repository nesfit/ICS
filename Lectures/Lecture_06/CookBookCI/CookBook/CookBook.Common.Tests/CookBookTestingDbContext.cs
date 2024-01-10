using CookBook.Common.Tests.Seeds;
using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Common.Tests
{
    public class CookBookTestingDbContext : CookBookDbContext
    {
        private readonly bool _seedTestingData;

        public CookBookTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false)
            : base(contextOptions, seedDemoData:false)
        {
            _seedTestingData = seedTestingData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_seedTestingData)
            {
                IngredientSeeds.Seed(modelBuilder);
                RecipeSeeds.Seed(modelBuilder);
                IngredientAmountSeeds.Seed(modelBuilder);
            }
        }
    }
}
