using System;
using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class IngredientAmountNewMessage : IMessage
    {
        public IngredientAmountNewMessage(Guid recipeId, IngredientAmountDetailModel model)
        {
            RecipeId = recipeId;
            Model = model;
        }

        public Guid RecipeId { get; }
        public IngredientAmountDetailModel Model { get; }
    }
}