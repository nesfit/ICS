using System;
using System.Linq;
using System.Threading.Tasks;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.DAL.Entities;
using CookBook.DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests : IDisposable
    {
        private readonly IngredientRepository _ingredientRepositorySUT;
        private readonly DbContextInMemoryFactory _dbContextFactory;

        public IngredientRepositoryTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(IngredientRepositoryTests));
            using var dbx = _dbContextFactory.Create();
            dbx.Database.EnsureCreated();

            _ingredientRepositorySUT = new IngredientRepository(_dbContextFactory);
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new IngredientDetailModel
            {
                Description = "Testovací ingredience",
                Name = "Ingredience 1"
            };

            var returnedModel = _ingredientRepositorySUT.InsertOrUpdate(model);

            Assert.NotNull(returnedModel);
        }

        [Fact]
        public void GetAll_Single_SeededWater()
        {
            var ingredient =  _ingredientRepositorySUT
                .GetAll()
                .Single(i => i.Id == IngredientSeeds.Water.Id);

            Assert.Equal(IngredientMapper.MapIngredientEntityToListModel(IngredientSeeds.Water), ingredient, IngredientListModel.AllMembersComparer);
        }

        [Fact]
        public void GetById_SeededWater()
        {
            var ingredient = _ingredientRepositorySUT.GetById(IngredientSeeds.Water.Id);

            Assert.Equal(IngredientMapper.MapIngredientEntityToDetailModel(IngredientSeeds.Water), ingredient, IngredientDetailModel.AllMembersComparer);
        }

        [Fact]
        public void SeededWater_DeleteById_Deleted()
        {
            _ingredientRepositorySUT.Delete(IngredientSeeds.Water.Id);

            using var dbxAssert = _dbContextFactory.Create();
            Assert.False(dbxAssert.Ingredients.Any(i => i.Id == IngredientSeeds.Water.Id));
        }


        [Fact]
        public void NewIngredient_InsertOrUpdate_IngredientAdded()
        {
            //Arrange
            var ingredient = new IngredientDetailModel()
            {
                Name = "Water",
                Description = "Mineral water"
            };

            //Act
            ingredient = _ingredientRepositorySUT.InsertOrUpdate(ingredient);

            //Assert
            using var dbxAssert = _dbContextFactory.Create();
            var ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapIngredientEntityToDetailModel(ingredientFromDb), IngredientDetailModel.AllMembersComparer);
        }

        [Fact]
        public void SeededWater_InsertOrUpdate_IngredientUpdated()
        {
            //Arrange
            var ingredient = new IngredientDetailModel()
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
            using var dbxAssert = _dbContextFactory.Create();
            var ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapIngredientEntityToDetailModel(ingredientFromDb), IngredientDetailModel.AllMembersComparer);
        }

        public void Dispose()
        {
            using var dbx = _dbContextFactory.Create();
            dbx.Database.EnsureDeleted();
        }
    }
}