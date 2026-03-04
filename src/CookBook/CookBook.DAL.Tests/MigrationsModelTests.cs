using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class MigrationsModelTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task ModelSnapshot_IsInSyncWithCurrentModel()
    {
        // Arrange
        await using var dbx = await DbContextFactory.CreateDbContextAsync();

        // Assert
        var hasDifferences = dbx.Database.HasPendingModelChanges();
        Assert.False(
            hasDifferences,
            "Pending model changes detected. Add a new EF migration to keep snapshot in sync.");
    }
}
