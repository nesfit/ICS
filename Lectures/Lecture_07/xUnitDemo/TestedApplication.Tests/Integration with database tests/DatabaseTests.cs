using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestedApplication.Database;
using Xunit;

namespace TestedApplication.Tests.Integration_with_database_tests
{
    public class DbContextFixture : IDisposable
    {
        private readonly string databaseName = Guid.NewGuid().ToString();

        public DbContextFixture()
        {
            PrepareDatabase();
        }

        public TasksDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TasksDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TasksTests;Persist Security Info=True;Integrated Security=True");
            //optionsBuilder.UseInMemoryDatabase(databaseName);
            optionsBuilder.EnableSensitiveDataLogging(true);
            var dbContext = new TasksDbContext(optionsBuilder.Options);
            return dbContext;
        }

        public void PrepareDatabase()
        {
            using (var dbContext = CreateDbContext())
            {
                dbContext.Database.EnsureCreated();
            }
        }

        public void TearDownDatabase()
        {
            using (var dbContext = CreateDbContext())
            {
                dbContext.Database.EnsureDeleted();
                dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            TearDownDatabase();
        }
    }
    public class TasksRepositoryFixture : IDisposable
    {
        public readonly TasksRepository Repository;
        public readonly DbContextFixture DbContextFixture=new DbContextFixture();
        public TasksRepositoryFixture()
        {
            Repository = new TasksRepository(DbContextFixture.CreateDbContext);
        }

        public void Dispose()
        {
            DbContextFixture?.Dispose();
        }
    }
    public class DatabaseTests : IDisposable
    {
        public readonly TasksRepositoryFixture RepositoryFixture;

        public DatabaseTests()
        {
            RepositoryFixture = new TasksRepositoryFixture();
        }

        [Fact]
        public async Task AddTask_Saves_Task_To_Database()
        {
            //arrange
            var repository = RepositoryFixture.Repository;
            var taskText = "This is test task";

            //act
            await repository.AddTaskAsync(taskText);

            //assert
            List<UserTask> tasks;
            using (var dbContext = RepositoryFixture.DbContextFixture.CreateDbContext())
            {
                tasks = dbContext.UserTasks.ToList();
            }
            Assert.Single(tasks);
            Assert.Equal(tasks.Single().Name,taskText);
        }
        [Fact]
        public async Task GetTask_Retrieves_Tasks_From_Database()
        {
            //arrange
            var repository = RepositoryFixture.Repository;
            var taskText = "This is test task";
            var userTask = new UserTask()
            {
                Name = taskText
            };

            using (var dbContext = RepositoryFixture.DbContextFixture.CreateDbContext())
            {
                await dbContext.UserTasks.AddAsync(userTask);
                await dbContext.SaveChangesAsync();
            }

            //act
            var tasks = (await repository.GetTasksAsync()).ToList();

            //assert
            
            Assert.Single(tasks);
            Assert.Equal(tasks.Single().Name,taskText);
        }

        public void Dispose()
        {
            RepositoryFixture?.Dispose();
        }
    }
}
