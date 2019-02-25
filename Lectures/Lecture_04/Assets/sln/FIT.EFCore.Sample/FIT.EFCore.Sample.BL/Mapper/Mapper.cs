using FIT.EFCore.Sample.BL.Model;
using FIT.EFCore.Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace FIT.EFCore.Sample.BL.Mapper
{
    public class Mapper : IMapper
    {
        public Person MapPersonToEntity(PersonModel model)
        {
            return new Person
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }

        public Todo MapTodoDetailToEntity(TodoDetailModel todo)
        {
            return new Todo
            {
                Id = todo.Id,
                IsDone = todo.IsDone,
                Task = todo.Task,
                AssignedPerson = MapPersonToEntity(todo.AssignedPerson)
            };
        }
    
        public PersonModel MapPersonListModelFromEntity(Person person)
        {
            return new PersonModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
        }

        public TodoListModel MapTodoListModelFromEntity(Todo todo)
        {
            return new TodoListModel
            {
                Id = todo.Id,
                IsDone = todo.IsDone,
                Task = todo.Task
            };
        }

        public TodoDetailModel MapTodoDetailModelFromEntity(Todo todo)
        {
            return new TodoDetailModel
            {
                Id = todo.Id,
                IsDone = todo.IsDone,
                Task = todo.Task,
                AssignedPerson = MapPersonListModelFromEntity(todo.AssignedPerson)
            };
        }
    }
}
