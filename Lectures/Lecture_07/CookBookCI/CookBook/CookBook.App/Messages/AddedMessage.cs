using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public record AddedMessage<T> : Message<T>
        where T : IModel
    {
    }
}