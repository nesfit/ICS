using System;

namespace CookBook.BL.Models;

public record IngredientAmountListModel : ModelBase
{
    public static IngredientAmountListModel Empty => new()
    {
        Id = Guid.NewGuid()
    };
}