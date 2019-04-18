using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class IngredientAmountNewMessage : IMessage
    {
        public IngredientAmountDetailModel Model { get; set; }
    }
}