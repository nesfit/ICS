using System;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.UnitOfWork;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<CookBookDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public IUnitOfWork Create() => new UnitOfWork(_dbContextFactory.CreateDbContext());
}