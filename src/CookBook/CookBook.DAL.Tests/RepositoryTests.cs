using CookBook.Common.Tests.Seeds;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class RepositoryTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task UpdateAsync_WithMissingEntity_ThrowsEntityNotFoundException()
    {
        // Arrange
        var repository = new Repository<IngredientEntity>(CookBookDbContextSUT, new IngredientEntityMapper());
        var missingEntity = IngredientSeeds.EmptyIngredient with
        {
            Id = Guid.Parse("57f1326b-128b-49d6-822f-d4b90db8594e"),
            Name = "Missing",
            Description = "Missing"
        };

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => repository.UpdateAsync(missingEntity));
    }

    [Fact]
    public async Task DeleteAsync_WithMissingEntity_ThrowsEntityNotFoundException()
    {
        // Arrange
        var repository = new Repository<IngredientEntity>(CookBookDbContextSUT, new IngredientEntityMapper());
        var missingEntityId = Guid.Parse("97218e82-63d9-480f-a2c4-305655e8d88a");

        // Act & Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(() => repository.DeleteAsync(missingEntityId));
    }
}
