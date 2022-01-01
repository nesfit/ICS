using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using CookBook.DAL.Factories;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextIngredientTests : IAsyncLifetime
    {
        private readonly DbContextInMemoryFactory _dbContextFactory;
        private readonly CookBookDbContext _cookBookDbContextSUT;

        public CookBookDbContextIngredientTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(CookBookDbContextTests), seedTestingData: true);
            _cookBookDbContextSUT = _dbContextFactory.CreateDbContext();
        }


        public async Task InitializeAsync()
        {
            await _cookBookDbContextSUT.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await _cookBookDbContextSUT.Database.EnsureDeletedAsync();
            await _cookBookDbContextSUT.DisposeAsync();
        }

        [Fact]
        public async Task AddNew_Ingredient_Persisted()
        {
            //Arrange
            IngredientEntity ingredientEntity = new(
                Guid.Parse("C5DE45D7-64A0-4E8D-AC7F-BF5CFDFB0EFC"),
                Name : "Salt",
                Description : "Mountain salt",
                ImageUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/Salt_shaker_on_white_background.jpg/800px-Salt_shaker_on_white_background.jpg"
            );

            //Act
            _cookBookDbContextSUT.Ingredients.Add(ingredientEntity);
            await _cookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = _dbContextFactory.CreateDbContext();
            var retrievedIngredient = await dbx.Ingredients.SingleAsync(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public async Task GetAll_Ingredients_ContainsSeededWater()
        {
            var ingredients = await _cookBookDbContextSUT.Ingredients.ToArrayAsync();
            Assert.Contains(IngredientSeeds.Water, ingredients);
        }

        [Fact]
        public async Task GetById_Ingredient_WaterRetrieved()
        {
            var ingredient = await _cookBookDbContextSUT.Ingredients.SingleAsync(i=>i.Id == IngredientSeeds.Water.Id);
            Assert.Equal(IngredientSeeds.Water, ingredient);
        }

        [Fact]
        public async Task Update_Ingredient_Persisted()
        {
            //Arrange
            var ingredientEntity =
                IngredientSeeds.WaterUpdate with
                {
                    Name = IngredientSeeds.Water.Name + "Updated",
                    Description = IngredientSeeds.Water.Description + "Updated",
                };

            //Act
            _cookBookDbContextSUT.Ingredients.Update(ingredientEntity);
            await _cookBookDbContextSUT.SaveChangesAsync();

            //Assert
            await using var dbx = _dbContextFactory.CreateDbContext();
            var retrievedIngredient = await dbx.Ingredients.SingleAsync(entity => entity.Id == ingredientEntity.Id);
            Assert.Equal(ingredientEntity, retrievedIngredient);
        }

        [Fact]
        public async Task Delete_Ingredient_WaterDeleted()
        {
            _cookBookDbContextSUT.Ingredients.Remove(IngredientSeeds.WaterDelete);
            await _cookBookDbContextSUT.SaveChangesAsync();

            Assert.False(await _cookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == IngredientSeeds.WaterDelete.Id));
        }

        [Fact]
        public async Task DeleteById_Ingredient_WaterDeleted()
        {
            _cookBookDbContextSUT.Remove(
                _cookBookDbContextSUT.Ingredients.Single(i => i.Id == IngredientSeeds.WaterDelete.Id));
            await _cookBookDbContextSUT.SaveChangesAsync();

            Assert.False(await _cookBookDbContextSUT.Ingredients.AnyAsync(i => i.Id == IngredientSeeds.WaterDelete.Id));
        }
    }
}
