using System.Threading.Tasks;
using CookBook.DAL.Factories;
using Xunit;

namespace CookBook.DAL.Tests;

public class CookBookDbContextTestsBase : IAsyncLifetime
{
    public CookBookDbContextTestsBase()
    {
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