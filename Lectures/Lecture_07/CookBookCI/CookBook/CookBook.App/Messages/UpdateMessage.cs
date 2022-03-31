using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public record UpdateMessage<T> : Message<T>
        where T : IModel
    {
    }
}
