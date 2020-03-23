using System;

namespace CookBook.BL.Messages
{
    public class IngredientDeletedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
