using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public record SelectedMessage<T> : Message<T>
        where T : IModel
    {
    }
}
