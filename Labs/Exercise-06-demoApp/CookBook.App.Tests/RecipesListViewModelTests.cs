using System.Collections.Generic;
using CookBook.App.ViewModels;
using CookBook.App.Wrappers;
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
        private readonly Mock<IRecipeRepository> _recipeRepositoryMock;
        private readonly Mock<Mediator> _mediatorMock;
        private readonly RecipeListViewModel _recipeListViewModelSUT;

        public RecipesListViewModelTests()
        {
            _recipeRepositoryMock = new Mock<IRecipeRepository>();
            _mediatorMock = new Mock<Mediator> {CallBase = true};

            _recipeRepositoryMock.Setup(repository => repository.GetAll())
                .Returns(() => new List<RecipeListModel>());

            _recipeListViewModelSUT = new RecipeListViewModel(_recipeRepositoryMock.Object, _mediatorMock.Object);
        }

        [Fact]
        public void Load_Calls_RecipeRepository_GetAll()
        {
            //Arrange
            //Act
            _recipeListViewModelSUT.Load();

            //Assert
            _recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void Load_FromEmptyRepository_GetAll()
        {
            //Arrange

            //Act
            _recipeListViewModelSUT.Load();

            //Assert
            _recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
            Assert.Empty(_recipeListViewModelSUT.Recipes);
        }

        [Fact]
        public void Load_OneRecipeFromRepository_GetAll()
        {
            //Arrange
            _recipeRepositoryMock.Setup(repository => repository.GetAll())
                .Returns(() => new List<RecipeListModel> {new RecipeListModel()});

            //Act
            _recipeListViewModelSUT.Load();

            //Assert
            Assert.True(_recipeListViewModelSUT.Recipes.Count == 1);
        }

        [Fact]
        public void RecipeUpdated_Calls_GetAll_FromRepository()
        {
            //Arrange

            //Act
            _mediatorMock.Object.Send(new UpdateMessage<RecipeWrapper>());

            //Assert
            _recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void RecipeDeleted_Calls_GetAll_FromRepository()
        {
            //Arrange
            
            //Act
            _mediatorMock.Object.Send(new DeleteMessage<RecipeWrapper>());

            //Assert
            _recipeRepositoryMock.Verify(repository => repository.GetAll(), Times.Once);
        }

        [Fact]
        public void RecipeSelectedCommand__Sends_RecipeSelectedMessage()
        {
            //Arrange
            //Act
            _recipeListViewModelSUT.RecipeSelectedCommand.Execute(new RecipeListModel());

            //Assert
            _mediatorMock.Verify(mediator => mediator.Send(It.IsAny<SelectedMessage<RecipeWrapper>>()),Times.Once);
        }

        [Fact]
        public void RecipeNewCommand__Sends_RecipeSelectedMessage()
        {
            //Arrange

            //Act
            _recipeListViewModelSUT.RecipeNewCommand.Execute(null);

            //Assert
            _mediatorMock.Verify(mediator => mediator.Send(It.IsAny<NewMessage<RecipeWrapper>>()), Times.Once);
        }
    }
}
