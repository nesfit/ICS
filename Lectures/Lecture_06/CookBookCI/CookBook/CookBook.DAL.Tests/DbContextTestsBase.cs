using System;
using System.Threading.Tasks;
using CookBook.Common.Tests;
using CookBook.Common.Tests.Factories;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class  DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);
        
        // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
        // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
        DbContextFactory = new DbContextSQLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        
        CookBookDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<CookBookDbContext> DbContextFactory { get; }
    protected CookBookDbContext CookBookDbContextSUT { get; }


    public async Task InitializeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.DisposeAsync();
    }
}