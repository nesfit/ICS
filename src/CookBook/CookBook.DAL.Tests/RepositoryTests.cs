using CookBook.Common.Tests.Seeds;
using CookBook.DAL.Entities;
using CookBook.DAL.Mappers;
using CookBook.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.DAL.Tests;

public class RepositoryTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task UpdateAsync_WithExistingEntity_MapsAndPersistsChanges()
    {
        // Arrange
        var repository = new Repository<IngredientEntity>(CookBookDbContextSUT, new IngredientEntityMapper());
        var updatedEntity = IngredientSeeds.Water with
        {
            Name = "Water updated",
            Description = "Mineral water updated"
        };

        // Act
        var result = await repository.UpdateAsync(updatedEntity);
        await CookBookDbContextSUT.SaveChangesAsync();

        // Assert
        Assert.Equal(updatedEntity.Name, result.Name);
        Assert.Equal(updatedEntity.Description, result.Description);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        var persisted = await dbxAssert.Ingredients.SingleAsync(i => i.Id == updatedEntity.Id);
        Assert.Equal(updatedEntity.Name, persisted.Name);
        Assert.Equal(updatedEntity.Description, persisted.Description);
    }

    [Fact]
    public async Task DeleteAsync_WithExistingEntity_RemovesEntity()
    {
        // Arrange
        var repository = new Repository<IngredientEntity>(CookBookDbContextSUT, new IngredientEntityMapper());
        var entityId = IngredientSeeds.Water.Id;

        // Act
        await repository.DeleteAsync(entityId);
        await CookBookDbContextSUT.SaveChangesAsync();

        // Assert
        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Ingredients.AnyAsync(i => i.Id == entityId));
    }

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
