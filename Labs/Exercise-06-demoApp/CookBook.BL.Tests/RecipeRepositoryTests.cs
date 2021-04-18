using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Mappers;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Enums;
using CookBook.DAL.Seeds;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests
{
    public class RecipeRepositoryTests : IDisposable
    {
        private readonly RecipeRepository _repositorySUT;
        private readonly DbContextInMemoryFactory _dbContextFactory;

        public RecipeRepositoryTests(ITestOutputHelper output)
        {
            XUnitTestOutputConverter converter = new XUnitTestOutputConverter(output);
            Console.SetOut(converter);

            _dbContextFactory = new DbContextInMemoryFactory(nameof(RecipeRepositoryTests));
            using CookBookDbContext dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            _repositorySUT = new RecipeRepository(_dbContextFactory);
        }

        [Fact]
        public void Create_WithWithoutIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            RecipeDetailModel model = new RecipeDetailModel
            {
                Name = "Recipe 1",
                Description = "Testing recipe 1",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert
            }; 

             //Act
             RecipeDetailModel returnedModel = _repositorySUT.InsertOrUpdate(model);

            //Assert
            FixIds(model, returnedModel);
            Assert.Equal(model, returnedModel);
        }

        [Fact]
        public void Create_WithNonExistingIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            RecipeDetailModel model = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients = {
                    new IngredientAmountDetailModel
                    {
                        IngredientName = "Ingredient 1",
                        IngredientDescription = "Testing Ingredient",
                    }
                }
            };

            //Act
            RecipeDetailModel returnedModel = _repositorySUT.InsertOrUpdate(model);


            //Assert
            Assert.NotEqual(Guid.Empty, returnedModel.Id);
            Assert.NotEqual(Guid.Empty, returnedModel.Ingredients.First().Id);
            FixIds(returnedModel, model);

            Assert.Equal(model, returnedModel);
        }

        [Fact]
        public void Create_WithIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            RecipeDetailModel model = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                ImageUrl = "https://d2v9mhsiek5lbq.cloudfront.net/eyJidWNrZXQiOiJsb21hLW1lZGlhLXVrIiwia2V5IjoiZm9vZG5ldHdvcmstaW1hZ2UtOGI5ZWM4YTAtODc1OC00MDcyLTg2YTItMzMzYTA4NTY5NTkwLmpwZyIsImVkaXRzIjp7InJlc2l6ZSI6eyJmaXQiOiJjb3ZlciIsIndpZHRoIjo3NTAsImhlaWdodCI6NDIyfX19",
                Ingredients = {
                    new IngredientAmountDetailModel
                    {
                        IngredientName = IngredientSeeds.IngredientEntity1.Name,
                        IngredientDescription = IngredientSeeds.IngredientEntity1.Description,
                        IngredientImageUrl = IngredientSeeds.IngredientEntity1.ImageUrl,
                        IngredientId = IngredientSeeds.IngredientEntity1.Id,

                        Amount = 5,
                        Unit = Unit.L
                    }
                }
            };

            //Act
            RecipeDetailModel returnedModel = _repositorySUT.InsertOrUpdate(model);

            //Assert
            FixIds(model, returnedModel);
            Assert.Equal(model,returnedModel);
        }

        [Fact]
        public void Create_WithExistingAndNotExistingIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            RecipeDetailModel model = new RecipeDetailModel
            {
                Name = "Recipe 2",
                Description = "Testing recipe 2",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients = {
                    new IngredientAmountDetailModel
                    {
                        IngredientName = "Ingredient 1",
                        IngredientDescription = "Testing Ingredient",
                    },
                    IngredientAmountMapper.MapEntityToDetailModel(DAL.Seeds.IngredientAmountSeeds.IngredientAmountEntity1)
                }
            };

            //Act
            RecipeDetailModel returnedModel = _repositorySUT.InsertOrUpdate(model);


            //Assert
            Assert.NotEqual(Guid.Empty, returnedModel.Id);
            Assert.NotEqual(Guid.Empty, returnedModel.Ingredients.First().Id);
            FixIds(returnedModel, model);

            Assert.Equal(model, returnedModel);
        }

        [Fact]
        public void GetById_FromSeeded_DoesNotThrowAndEqualsSeeded()
        {
            //Arrange
            RecipeDetailModel detailModel = RecipeMapper.MapEntityToDetailModel(DAL.Seeds.RecipeSeeds.RecipeEntity);

            //Act
            RecipeDetailModel returnedModel = _repositorySUT.GetById(detailModel.Id);

            //Assert
            Assert.Equal(detailModel, returnedModel);
        }

        [Fact]
        public void GetAll_FromSeeded_DoesNotThrowAndEqualsSeeded()
        {
            //Arrange
            RecipeListModel listModel = RecipeMapper.MapEntityToListModel(RecipeSeeds.RecipeEntity);

            //Act
            IEnumerable<RecipeListModel> returnedModel = _repositorySUT.GetAll();

            //Assert
            Assert.Equal(new [] { listModel}, returnedModel);
        }

        [Fact]
        public void Delete_FromSeeded_DoesNotThrow()
        {
            //Arrange
            RecipeDetailModel detailModel = RecipeMapper.MapEntityToDetailModel(DAL.Seeds.RecipeSeeds.RecipeEntity);

            //Act & Assert
            _repositorySUT.Delete(detailModel);
        }

        [Fact]
        public void Update_FromSeeded_DoesNotThrow()
        {
            //Arrange
            RecipeDetailModel detailModel = RecipeMapper.MapEntityToDetailModel(DAL.Seeds.RecipeSeeds.RecipeEntity);
            detailModel.Name = "Changed recipe name";

            //Act & Assert
            _repositorySUT.InsertOrUpdate(detailModel);
        }

        [Fact]
        public void Update_Name_FromSeeded_CheckUpdated()
        {
            //Arrange
            RecipeDetailModel detailModel = RecipeMapper.MapEntityToDetailModel(DAL.Seeds.RecipeSeeds.RecipeEntity);
            detailModel.Name = "Changed recipe name 1";

            //Act
            _repositorySUT.InsertOrUpdate(detailModel);

            //Assert
            RecipeDetailModel returnedModel = _repositorySUT.GetById(detailModel.Id);
            Assert.Equal(detailModel, returnedModel);
        }

        [Fact]
        public void Update_RemoveIngredients_FromSeeded_CheckUpdated()
        {
            //Arrange
            RecipeDetailModel detailModel = RecipeMapper.MapEntityToDetailModel(DAL.Seeds.RecipeSeeds.RecipeEntity);
            detailModel.Ingredients.Clear();

            //Act
            _repositorySUT.InsertOrUpdate(detailModel);

            //Assert
            RecipeDetailModel returnedModel = _repositorySUT.GetById(detailModel.Id);
            Assert.Equal(detailModel, returnedModel);
        }

        [Fact]
        public void DeleteById_FromSeeded_DoesNotThrow()
        {
            //Arrange & Act & Assert
            _repositorySUT.Delete(DAL.Seeds.RecipeSeeds.RecipeEntity.Id);
        }

        private static void FixIds(RecipeDetailModel expectedModel, RecipeDetailModel returnedModel)
        {
            returnedModel.Id = expectedModel.Id;

            foreach (IngredientAmountDetailModel ingredientAmountModel in returnedModel.Ingredients)
            {
                IngredientAmountDetailModel? ingredientAmountDetailModel = expectedModel.Ingredients.FirstOrDefault(i => 
                    i.IngredientName == ingredientAmountModel.IngredientName 
                    && i.IngredientDescription == ingredientAmountModel.IngredientDescription
                    && i.IngredientImageUrl == ingredientAmountModel.IngredientImageUrl
                    && Math.Abs(i.Amount - ingredientAmountModel.Amount) <= 0
                    && i.Unit == ingredientAmountModel.Unit);

                if (ingredientAmountDetailModel != null)
                {
                    ingredientAmountModel.Id = ingredientAmountDetailModel.Id;
                    ingredientAmountModel.IngredientId = ingredientAmountDetailModel.IngredientId;
                }

            }
        }

        public void Dispose()
        {
            using CookBookDbContext dbx = _dbContextFactory.CreateDbContext();
            dbx.Database.EnsureDeleted();
        }
     }
}