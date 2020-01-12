using System;
using CookBook.App.Wrappers;
using CookBook.BL.Models;

namespace CookBook.App.ViewModels
{
    public interface IRecipeDetailViewModel : IDetailViewModel<RecipeWrapper>
    {
    }
}