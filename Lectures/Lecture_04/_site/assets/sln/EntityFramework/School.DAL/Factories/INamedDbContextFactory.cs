using Microsoft.EntityFrameworkCore;

namespace School.DAL.Factories
{
    public interface INamedDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext Create();
    }
}