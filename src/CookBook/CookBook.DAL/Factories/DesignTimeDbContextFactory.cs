﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CookBook.DAL.Factories;

/// <summary>
///     EF Core CLI migration generation uses this DbContext to create model and migration
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CookBookDbContext>
{
    private readonly DbContextSqLiteFactory _dbContextSqLiteFactory;
    private const string ConnectionString = $"Data Source=CookBook;Cache=Shared";

    public DesignTimeDbContextFactory()
    {
        _dbContextSqLiteFactory = new DbContextSqLiteFactory(ConnectionString);
    }
    
    public CookBookDbContext CreateDbContext(string[] args) => _dbContextSqLiteFactory.CreateDbContext();
}
