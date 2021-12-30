using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public class DeleteMessage<T> : Message<T>
        where T : IModel
    {
    }
}