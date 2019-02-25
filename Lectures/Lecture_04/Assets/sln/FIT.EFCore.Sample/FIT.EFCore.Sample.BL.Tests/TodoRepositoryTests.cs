using System;
using System.Linq;
using FIT.EFCore.Sample.BL.Model;
using FIT.EFCore.Sample.BL.Repositories;
using FIT.EFCore.Sample.DAL.Tests;
using Xunit;

namespace FIT.EFCore.Sample.BL.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public void GetAll_WithNoData_ReturnsEmptyEnumerable()
        {
            //Arrange
            var sut = CreateSUT();

            //Act
            var models = sut.GetAll();

            //Assert
            Assert.False(models.Any());
        }

        [Fact]
        public void FindById_ExistingItem_ReturnsIt()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TodoDetailModel
            {
                IsDone = true,
                Task = "Take out trash",
                AssignedPerson = new PersonModel
                {
                    FirstName = "Karel",
                    LastName = "Omáčka"
                }
            };
            var createdModel = sut.Add(model);
            try
            {
                //Act
                var foundModel = sut.GetById(createdModel.Id);

                //Assert
                Assert.NotNull(foundModel);
            }
            finally
            {
                //Teardown
                sut.Remove(createdModel.Id);
            }
        }

        [Fact]
        public void Remove_ExistingItem_RemovesIt()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TodoDetailModel
            {
                IsDone = true,
                Task = "Take out trash",
                AssignedPerson = new PersonModel
                {
                    FirstName = "Karel",
                    LastName = "Omáčka"
                }
            };
            var createdModel = sut.Add(model);

            //Act
            sut.Remove(createdModel.Id);

            //Assert
            Assert.Null(sut.GetById(createdModel.Id));
        }

        [Fact]
        public void Add_WithValidData_ReturnsCreatedItem()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TodoDetailModel
            {
                IsDone = true,
                Task = "Take out trash",
                AssignedPerson = new PersonModel
                {
                    FirstName = "Karel",
                    LastName = "Omáčka"
                }
            };

            TodoDetailModel createdModel = null;
            try
            {
                //Act
                createdModel = sut.Add(model);

                //Assert
                Assert.NotNull(createdModel);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.Remove(createdModel.Id);
                }
            }
        }

        private ITodosRepository CreateSUT()
        {
            return new TodosRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
        }
    }
}