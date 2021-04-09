using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public class UpdateMessage<T> : Message<T>
        where T : IModel
    {
    }
}
