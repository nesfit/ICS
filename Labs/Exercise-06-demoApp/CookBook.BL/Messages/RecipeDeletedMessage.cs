using System;

namespace CookBook.BL.Messages
{
    public class RecipeDeletedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}