using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class IngredientAmountDeleteMessage : IMessage
    {
        public IngredientAmountDetailModel Model { get; set; }
    }
}