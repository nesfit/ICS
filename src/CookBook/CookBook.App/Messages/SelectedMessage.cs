using CookBook.BL.Models;

namespace CookBook.App.Messages
{
    public class SelectedMessage<T> : Message<T>
        where T : IModel
    {
    }
}
