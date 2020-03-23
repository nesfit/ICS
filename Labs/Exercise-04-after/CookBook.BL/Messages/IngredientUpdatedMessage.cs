using System;

namespace CookBook.BL.Messages
{
    public class IngredientUpdatedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
