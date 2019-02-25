using System.Collections.Generic;
using FIT.EFCore.Sample.BL.Model;
using FIT.EFCore.Sample.DAL.Entities;

namespace FIT.EFCore.Sample.BL.Repositories
{
    public interface ITodosRepository
    {
        IEnumerable<TodoListModel> GetAll();
        TodoDetailModel GetById(int id);
        void Update(TodoDetailModel todo);
        TodoDetailModel Add(TodoDetailModel todo);
        void Remove(int id);
    }
}
