using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public record DeleteMessage<T> : Message<T>
        where T : IModel
    {
    }
}