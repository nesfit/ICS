using CookBook.Common.Tests;
using CookBook.Common.Tests.Factories;
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

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);
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
