using FIT.EFCore.Sample.BL.Model;
using FIT.EFCore.Sample.DAL.Entities;

namespace FIT.EFCore.Sample.BL.Mapper
{
    public interface IMapper
    {
        Person MapPersonToEntity(PersonModel model);
        Todo MapTodoDetailToEntity(TodoDetailModel todo);
        PersonModel MapPersonListModelFromEntity(Person person);
        TodoListModel MapTodoListModelFromEntity(Todo todo);
        TodoDetailModel MapTodoDetailModelFromEntity(Todo todo);
    }
}