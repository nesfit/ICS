using System;

namespace CookBook.App.Messages
{
    public class IngredientAddedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}