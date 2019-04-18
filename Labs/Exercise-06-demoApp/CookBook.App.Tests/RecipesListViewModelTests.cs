using System;
using System.Collections.Generic;
using CookBook.App.ViewModels;
using CookBook.BL.Interfaces;
using CookBook.BL.Messages;
using CookBook.BL.Models;
using CookBook.BL.Services;
using Moq;
using Xunit;

namespace CookBook.App.Tests
{
    public class RecipesListViewModelTests
    {
        private readonly Mock<IRecipeRepository> recipeRepositoryMock;
        private readonly Mock<Mediator> mediatorMock;
        private readonly RecipesListViewModel recipesListViewModelSUT;

        public RecipesListViewModelTests()
        {
            this.recipeRepositoryMock = new Mock<IRecipeRepository>();
            this.mediatorMock = new Mock<Mediator>(){CallBase = true};

            recipeRepositoryMock.Setup(repository => repository.GetAll())
                .Returns(() => new List<RecipeListModel>());

            this.recipesListViewModelSUT = new RecipesListViewModel(recipeRepositoryMock.Object, mediatorMock.Object);
        }

        [Fact]
        public void Load_Calls_RecipeRepository_GetAll()
        {
            //Arrange
            //Act
            recipesListViewModelSUT.Load();

            //Assert
            recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void Load_FromEmptyRepository_GetAll()
        {
            //Arrange

            //Act
            recipesListViewModelSUT.Load();

            //Assert
            recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
            Assert.Empty(recipesListViewModelSUT.Recipes);
        }

        [Fact]
        public void Load_OneRecipeFromRepository_GetAll()
        {
            //Arrange
            recipeRepositoryMock.Setup(repository => repository.GetAll())
                .Returns(() => new List<RecipeListModel>(){new RecipeListModel()});

            //Act
            recipesListViewModelSUT.Load();

            //Assert
            Assert.True(recipesListViewModelSUT.Recipes.Count == 1);
        }

        [Fact]
        public void RecipeUpdated_Calls_GetAll_FromRepository()
        {
            //Arrange

            //Act
            mediatorMock.Object.Send(new RecipeUpdatedMessage());

            //Assert
            recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void RecipeDeleted_Calls_GetAll_FromRepository()
        {
            //Arrange
            
            //Act
            mediatorMock.Object.Send(new RecipeDeletedMessage());

            //Assert
            recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void RecipeSelectedCommand__Sends_RecipeSelectedMessage()
        {
            //Arrange
            //Act
            recipesListViewModelSUT.RecipeSelectedCommand.Execute(new RecipeListModel());

            //Assert
            mediatorMock.Verify(mediator => mediator.Send(It.IsAny<RecipeSelectedMessage>()),Times.Once);
        }

        [Fact]
        public void RecipeNewCommand__Sends_RecipeSelectedMessage()
        {
            //Arrange

            //Act
            recipesListViewModelSUT.RecipeNewCommand.Execute(null);

            //Assert
            mediatorMock.Verify(mediator => mediator.Send(It.IsAny<RecipeNewMessage>()), Times.Once);
        }
    }
}
