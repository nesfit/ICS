using System;

namespace CookBook.BL.Messages
{
    public class IngredientAddedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}