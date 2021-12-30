using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public class AddedMessage<T> : Message<T>
        where T : IModel
    {
    }
}