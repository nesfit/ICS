using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public interface INamedDbContextFactory<out TDbContext>
        where TDbContext : DbContext
    {
        TDbContext Create();
    }
}