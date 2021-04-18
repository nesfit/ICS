using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public class NewMessage<T> : Message<T>
        where T : IModel
    {
    }
}
