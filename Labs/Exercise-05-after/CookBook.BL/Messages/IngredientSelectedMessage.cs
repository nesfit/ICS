using System;

namespace CookBook.BL.Messages
{
    public class IngredientSelectedMessage : IMessage
    {
        public Guid Id { get; set; }
    }

}
