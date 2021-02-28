using Microsoft.EntityFrameworkCore;

namespace School.DAL.Factories
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext Create();
    }
}