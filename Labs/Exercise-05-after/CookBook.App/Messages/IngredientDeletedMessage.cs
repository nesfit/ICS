using System;

namespace CookBook.App.Messages
{
    public class IngredientDeletedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
