using System.Collections.Generic;
using System.Linq;
using FIT.EFCore.Sample.BL.Mapper;
using FIT.EFCore.Sample.BL.Model;
using FIT.EFCore.Sample.DAL;
using FIT.EFCore.Sample.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIT.EFCore.Sample.BL.Repositories
{
    public class TodosRepository : ITodosRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;
        public TodosRepository(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public IEnumerable<TodoListModel> GetAll()
        {
            return dbContextFactory.CreateDbContext()
                .Todos
                .Select(mapper.MapTodoListModelFromEntity);
        }

        public TodoDetailModel GetById(int id)
        {
            var foundEntity = dbContextFactory
                .CreateDbContext()
                .Todos
                .Include(t => t.AssignedPerson)
                .FirstOrDefault(t => t.Id == id);
            return foundEntity == null ? null : mapper.MapTodoDetailModelFromEntity(foundEntity);
        }

        public void Update(TodoDetailModel todo)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapTodoDetailToEntity(todo);
                dbContext.Todos.Update(entity);
                dbContext.SaveChanges();
            }
        }

        public TodoDetailModel Add(TodoDetailModel todo)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var entity = mapper.MapTodoDetailToEntity(todo);
                dbContext.Todos.Add(entity);
                dbContext.SaveChanges();
                return mapper.MapTodoDetailModelFromEntity(entity);
            }
        }

        public void Remove(int id)
        {
            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var todo = new Todo
                {
                    Id = id
                };
                dbContext.Todos.Attach(todo);
                dbContext.Todos.Remove(todo);
                dbContext.SaveChanges();
            }
        }
    }
}