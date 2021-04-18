using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Factories;
using CookBook.DAL.Seeds;
using System;
using System.Linq;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.BL.Tests
{
    public sealed class IngredientRepositoryTests : IDisposable
    {
        private readonly IngredientRepository _ingredientRepositorySUT;
        private readonly IDbContextFactory<CookBookDbContext> _dbContextFactory;

        public IngredientRepositoryTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(IngredientRepositoryTests));
            using CookBookDbContext dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            _ingredientRepositorySUT = new IngredientRepository(_dbContextFactory);
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            IngredientDetailModel model = new IngredientDetailModel
            {
                Description = "Testovací ingredience",
                Name = "Ingredience 1"
            };

            IngredientDetailModel returnedModel = _ingredientRepositorySUT.InsertOrUpdate(model);
        }

        [Fact]
        public void GetAll_Single_SeededWater()
        {
            IngredientListModel ingredient = _ingredientRepositorySUT
                .GetAll()
                .Single(i => i.Id == IngredientSeeds.Water.Id);

            Assert.Equal(IngredientMapper.MapEntityToListModel(IngredientSeeds.Water), ingredient);
        }

        [Fact]
        public void GetById_SeededWater()
        {
            IngredientDetailModel ingredient = _ingredientRepositorySUT.GetById(IngredientSeeds.Water.Id);

            Assert.Equal(IngredientMapper.MapEntityToDetailModel(IngredientSeeds.Water), ingredient);
        }

        [Fact]
        public void SeededWater_DeleteById_Deleted()
        {
            _ingredientRepositorySUT.Delete(IngredientSeeds.Water.Id);

            using CookBookDbContext dbxAssert = _dbContextFactory.CreateDbContext();
            Assert.False(dbxAssert.Ingredients.Any(i => i.Id == IngredientSeeds.Water.Id));
        }


        [Fact]
        public void NewIngredient_InsertOrUpdate_IngredientAdded()
        {
            //Arrange
            IngredientDetailModel ingredient = new IngredientDetailModel()
            {
                Name = "Water",
                Description = "Mineral water"
            };

            //Act
            ingredient = _ingredientRepositorySUT.InsertOrUpdate(ingredient);

            //Assert
            using CookBookDbContext dbxAssert = _dbContextFactory.CreateDbContext();
            IngredientEntity ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapEntityToDetailModel(ingredientFromDb));
        }

        [Fact]
        public void SeededWater_InsertOrUpdate_IngredientUpdated()
        {
            //Arrange
            IngredientDetailModel ingredient = new IngredientDetailModel()
            {
                Id = IngredientSeeds.Water.Id,
                Name = IngredientSeeds.Water.Name,
                Description = IngredientSeeds.Water.Description,
            };
            ingredient.Name += "updated";
            ingredient.Description += "updated";

            //Act
            _ingredientRepositorySUT.InsertOrUpdate(ingredient);

            //Assert
            using CookBookDbContext dbxAssert = _dbContextFactory.CreateDbContext();
            IngredientEntity ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapEntityToDetailModel(ingredientFromDb));
        }

        public void Dispose()
        {
            using CookBookDbContext dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureDeleted();
        }
    }
}