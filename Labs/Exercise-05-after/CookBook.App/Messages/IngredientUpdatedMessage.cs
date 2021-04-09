using System;

namespace CookBook.App.Messages
{
    public class IngredientUpdatedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
