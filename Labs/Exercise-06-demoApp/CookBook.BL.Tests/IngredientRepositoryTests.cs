using System;
using System.Linq;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.DAL.Seeds;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests : IClassFixture<IngredientRepositoryTestsFixture>, IDisposable
    {
        private readonly IngredientRepositoryTestsFixture _fixture;

        public IngredientRepositoryTests(IngredientRepositoryTestsFixture fixture)
        {
            _fixture = fixture;

            _fixture.PrepareDatabase();
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrow()
        {
            var model = new IngredientDetailModel
            {
                Description = "Testovací ingredience",
                Name = "Ingredience 1"
            };

            var returnedModel = _fixture.Repository.InsertOrUpdate(model);

            Assert.NotNull(returnedModel);

            _fixture.Repository.Delete(returnedModel.Id);
        }


        [Fact]
        public void GetAll_Single_SeededWater()
        {
            var ingredient = _fixture.Repository
                .GetAll()
                .Single(i => i.Id == Seeds.Water.Id);

            Assert.Equal(IngredientMapper.MapListModel(Seeds.Water), ingredient, IngredientListModel.AllMembersComparer);
        }

        [Fact]
        public void GetById_SeededWater()
        {
            var ingredient = _fixture.Repository.GetById(Seeds.Water.Id);

            Assert.Equal(IngredientMapper.MapDetailModel(Seeds.Water), ingredient, IngredientDetailModel.AllMembersComparer);
        }

        [Fact]
        public void SeededWater_DeleteById_Deleted()
        {
            _fixture.Repository.Delete(Seeds.Water.Id);

            using var dbxAssert = _fixture.DbContextFactory.CreateDbContext();
            Assert.False(dbxAssert.Ingredients.Any(i => i.Id == Seeds.Water.Id));
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
            ingredient = _fixture.Repository.InsertOrUpdate(ingredient);

            //Assert
            using var dbxAssert = _fixture.DbContextFactory.CreateDbContext();
            var ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapDetailModel(ingredientFromDb), IngredientDetailModel.AllMembersComparer);
        }

        [Fact]
        public void SeededWater_InsertOrUpdate_IngredientUpdated()
        {
            //Arrange
            var ingredient = new IngredientDetailModel()
            {
                Id = Seeds.Water.Id,
                Name = Seeds.Water.Name,
                Description = Seeds.Water.Description,
            };
            ingredient.Name += "updated";
            ingredient.Description += "updated";

            //Act
            _fixture.Repository.InsertOrUpdate(ingredient);

            //Assert
            using var dbxAssert = _fixture.DbContextFactory.CreateDbContext();
            var ingredientFromDb = dbxAssert.Ingredients.Single(i => i.Id == ingredient.Id);
            Assert.Equal(ingredient, IngredientMapper.MapDetailModel(ingredientFromDb), IngredientDetailModel.AllMembersComparer);
        }


        public void Dispose()
        {
            _fixture.TearDownDatabase();
        }
    }
}