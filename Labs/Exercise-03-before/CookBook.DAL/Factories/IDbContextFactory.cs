using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext Create();
    }
}