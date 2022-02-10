using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public record NewMessage<T> : Message<T>
        where T : IModel
    {
    }
}
