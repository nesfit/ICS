using System;

namespace CookBook.App.Messages
{
    public class IngredientSelectedMessage : IMessage
    {
        public Guid Id { get; set; }
    }

}
