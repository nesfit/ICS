using System;
using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class IngredientAmountSelectedMessage:IMessage
    {
        public IngredientAmountDetailModel IngredientAmountDetailModel { get; set; }
    }
}