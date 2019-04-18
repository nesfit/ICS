using System;

namespace CookBook.BL.Messages
{
    public class RecipeUpdatedMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}