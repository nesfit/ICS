using FIT.EFCore.Sample.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace FIT.EFCore.Sample.DAL.Tests
{
    public class TodosDbContextTests
    {
        private readonly IDbContextFactory dbContextFactory;

        public TodosDbContextTests()
        {
            dbContextFactory = new InMemoryDbContextFactory();
        }

        [Fact]
        public void CreatePersonTest()
        {
            //Arrange
            var person = new Person
            {
                FirstName = "Joe",
                LastName = "Doe"
            };

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.People.Add(person);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Person retrievedPerson = null;
                try
                {
                    retrievedPerson = dbContext.People.First(t => t.Id == person.Id);
                    Assert.NotNull(retrievedPerson);
                }
                finally
                {
                    //Teardown
                    if (retrievedPerson != null)
                    {
                        dbContext.People.Remove(retrievedPerson);
                    }
                }
            }
        }

        [Fact]
        public void UpdatePersonTest()
        {
            //Arrange
            var person = new Person
            {
                FirstName = "Joe",
                LastName = "Doe"
            };
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.People.Add(person);
                dbContext.SaveChanges();
            }

            //Act
            person.LastName = "Smith";
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.People.Update(person);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Person retrievedPerson = null;
                try
                {
                    retrievedPerson = dbContext.People.First(t => t.Id == person.Id);
                    Assert.NotNull(retrievedPerson);
                    Assert.Equal("Smith", retrievedPerson.LastName);
                }
                finally
                {
                    //Teardown
                    if (retrievedPerson != null)
                    {
                        dbContext.People.Remove(retrievedPerson);
                    }
                }
            }
        }

        [Fact]
        public void RemovePersonTest()
        {
            //Arrange
            var person = new Person
            {
                FirstName = "Joe",
                LastName = "Doe"
            };
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.People.Add(person);
                dbContext.SaveChanges();
            }

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.People.Remove(person);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var retrievedPerson = dbContext.People.FirstOrDefault(t => t.Id == person.Id);
                Assert.Null(retrievedPerson);
            }
        }

        [Fact]
        public void CreateTodoTest()
        {
            //Arrange
            var todo = new Todo
            {
                AssignedPerson = new Person
                {
                    FirstName = "Joe",
                    LastName = "Doe"
                },
                IsDone = false,
                Task = "Buy candy"
            };

            //Act
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Todos.Add(todo);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                Todo retrievedTodo = null;
                try
                {
                    retrievedTodo = dbContext.Todos
                        .Include(t => t.AssignedPerson)
                        .First(t => t.Id == todo.Id);
                    Assert.NotNull(retrievedTodo);
                    Assert.NotNull(retrievedTodo.AssignedPerson);
                    var retrievedPerson = dbContext.People
                        .First(p => p.Id == todo.AssignedPerson.Id);
                    Assert.NotNull(retrievedPerson);
                }
                finally
                {
                    //Teardown
                    if (retrievedTodo != null)
                        dbContext.Remove(retrievedTodo);
                }
            }
        }
    }
}
