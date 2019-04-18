using System;

namespace CookBook.BL.Messages
{
    public class RecipeSelectedMessage:IMessage
    {
        public Guid Id { get; set; }
    }
}