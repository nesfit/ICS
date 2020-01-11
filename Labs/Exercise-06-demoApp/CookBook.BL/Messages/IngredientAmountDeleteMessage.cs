using System;
using CookBook.BL.Models;

namespace CookBook.BL.Messages
{
    public class IngredientAmountDeleteMessage : IMessage
    {
        public IngredientAmountDeleteMessage(Guid recipeId, IngredientAmountDetailModel model)
        {
            RecipeId = recipeId;
            Model = model;
        }

        public Guid RecipeId { get; }
        public IngredientAmountDetailModel Model { get; }
    }
}