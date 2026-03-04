using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.DAL.UnitOfWork;

public class UnitOfWorkFactory(
    IDbContextFactory<CookBookDbContext> dbContextFactory,
    IServiceScopeFactory serviceScopeFactory) : IUnitOfWorkFactory
{
    public IUnitOfWork Create()
    {
        var scope = serviceScopeFactory.CreateScope();
        return new UnitOfWork(dbContextFactory.CreateDbContext(), scope);
    }
}
