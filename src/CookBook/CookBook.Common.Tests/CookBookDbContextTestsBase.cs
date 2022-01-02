using CookBook.DAL;
using CookBook.DAL.Factories;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.Common.Tests;

public class CookBookDbContextTestsBase : IAsyncLifetime
{
    protected CookBookDbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);
        
        DbContextFactory = new DbContextInMemoryFactory(this.GetType().Name, seedTestingData: true);
        CookBookDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected DbContextInMemoryFactory DbContextFactory { get; }
    protected CookBookDbContext CookBookDbContextSUT { get; }


    public async Task InitializeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await CookBookDbContextSUT.Database.EnsureDeletedAsync();
        await CookBookDbContextSUT.DisposeAsync();
    }
}
