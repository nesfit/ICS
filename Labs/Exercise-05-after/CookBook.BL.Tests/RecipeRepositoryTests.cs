using System;
using System.Linq;
using CookBook.BL.Enums;
using CookBook.BL.Mapper;
using CookBook.BL.Models;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Seeds;
using Xunit;
using Xunit.Abstractions;

namespace CookBook.BL.Tests
{
    public class RecipeRepositoryTests : IClassFixture<RecipeRepositoryTestsFixture>, IDisposable
    {
        private readonly RecipeRepositoryTestsFixture _recipeRepositoryTestsFixture;

        private RecipeRepository RepositorySUT => _recipeRepositoryTestsFixture.Repository;

        public RecipeRepositoryTests(RecipeRepositoryTestsFixture recipeRepositoryTestsFixture, ITestOutputHelper output)
        {
            var converter = new XUnitTestOutputConverter(output);
            Console.SetOut(converter);
            _recipeRepositoryTestsFixture = recipeRepositoryTestsFixture;

            _recipeRepositoryTestsFixture.PrepareDatabase();
        }

        [Fact]
        public void Create_WithNonExistingItem_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            var model = new RecipeDetailModel
            {
                Name = "Recipe 1",
                Description = "Testing recipe 1",
                Duration = TimeSpan.FromHours(2),
                FoodType = FoodType.Dessert,
                Ingredients = { }
            }; 

             //Act
             var returnedModel = RepositorySUT.InsertOrUpdate(model);

            //Assert
            Assert.Equal(model, returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void Create_WithIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            var model = new RecipeDetailModel
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
            var returnedModel = RepositorySUT.InsertOrUpdate(model);

            
            //Assert
            Assert.NotEqual(Guid.Empty, returnedModel.Id);
            Assert.NotEqual(Guid.Empty, returnedModel.Ingredients.First().Id);
            FixIds(returnedModel, model);

            Assert.Equal(model,returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void Create_WithExistingIngredient_DoesNotThrowAndEqualsCreated()
        {
            //Arrange
            var model = new RecipeDetailModel
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
                    IngredientAmountMapper.MapDetailModel(DAL.Seeds.Seeds.IngredientAmountEntity1)
                }
            };

            //Act
            var returnedModel = RepositorySUT.InsertOrUpdate(model);


            //Assert
            Assert.NotEqual(Guid.Empty, returnedModel.Id);
            Assert.NotEqual(Guid.Empty, returnedModel.Ingredients.First().Id);
            FixIds(returnedModel, model);

            Assert.Equal(model, returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void GetById_FromSeeded_DoesNotThrowAndEqualsSeeded()
        {
            //Arrange
            var detailModel = RecipeMapper.MapToDetailModel(DAL.Seeds.Seeds.RecipeEntity);

            //Act
            var returnedModel = RepositorySUT.GetById(detailModel.Id);

            //Assert
            Assert.Equal(detailModel, returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void GetAll_FromSeeded_DoesNotThrowAndEqualsSeeded()
        {
            //Arrange
            var listModel = RecipeMapper.MapToListModel(DAL.Seeds.Seeds.RecipeEntity);

            //Act
            var returnedModel = RepositorySUT.GetAll();

            //Assert
            Assert.Equal(new [] { listModel}, returnedModel, RecipeListModel.NameDurationFoodTypeComparer);
        }

        [Fact]
        public void Delete_FromSeeded_DoesNotThrow()
        {
            //Arrange
            var detailModel = RecipeMapper.MapToDetailModel(DAL.Seeds.Seeds.RecipeEntity);

            //Act & Assert
            RepositorySUT.Delete(detailModel);
        }

        [Fact]
        public void Update_FromSeeded_DoesNotThrow()
        {
            //Arrange
            var detailModel = RecipeMapper.MapToDetailModel(DAL.Seeds.Seeds.RecipeEntity);
            detailModel.Name = "Changed recipe name";

            //Act & Assert
            RepositorySUT.InsertOrUpdate(detailModel);
        }

        [Fact]
        public void Update_Name_FromSeeded_CheckUpdated()
        {
            //Arrange
            var detailModel = RecipeMapper.MapToDetailModel(DAL.Seeds.Seeds.RecipeEntity);
            detailModel.Name = "Changed recipe name 1";

            //Act
            RepositorySUT.InsertOrUpdate(detailModel);

            //Assert
            var returnedModel = RepositorySUT.GetById(detailModel.Id);
            Assert.Equal(detailModel, returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void Update_RemoveIngredients_FromSeeded_CheckUpdated()
        {
            //Arrange
            var detailModel = RecipeMapper.MapToDetailModel(DAL.Seeds.Seeds.RecipeEntity);
            detailModel.Ingredients.Clear();

            //Act
            RepositorySUT.InsertOrUpdate(detailModel);

            //Assert
            var returnedModel = RepositorySUT.GetById(detailModel.Id);
            Assert.Equal(detailModel, returnedModel, RecipeDetailModel.RecipeDetailModelComparer);
        }

        [Fact]
        public void DeleteById_FromSeeded_DoesNotThrow()
        {
            //Arrange & Act & Assert
            RepositorySUT.Delete(DAL.Seeds.Seeds.RecipeEntity.Id);
        }
        
        private static void FixIds(RecipeDetailModel returnedModel, RecipeDetailModel model)
        {
            model.Id = returnedModel.Id;
            foreach (var ingredient in returnedModel.Ingredients)
            {
               var ingredientAmountDetailModel = model.Ingredients.FirstOrDefault(i =>
                    IngredientAmountDetailModel.IngredientAmountDetailModelWithoutIdComparer.Equals(i, ingredient));
               if (ingredientAmountDetailModel != null)
               {
                   ingredientAmountDetailModel.Id = ingredient.Id;
                   ingredientAmountDetailModel.IngredientId = ingredient.IngredientId;
               }
            }
        }

        public void Dispose()
        {
            _recipeRepositoryTestsFixture.TearDownDatabase();
        }
     }
}