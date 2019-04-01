using CookBook.BL.Factories;
using CookBook.DAL;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BL.Tests
{
    class InMemoryDbContextFactory : IDbContextFactory
    {
        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseInMemoryDatabase("CookbookDB");
            return new CookBookDbContext(optionsBuilder.Options);
        }
    }
}