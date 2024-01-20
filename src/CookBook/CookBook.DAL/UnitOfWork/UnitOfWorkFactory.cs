using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class UnitOfWorkFactory(IDbContextFactory<CookBookDbContext> dbContextFactory) : IUnitOfWorkFactory
{
    public IUnitOfWork Create() => new UnitOfWork(dbContextFactory.CreateDbContext());
}
