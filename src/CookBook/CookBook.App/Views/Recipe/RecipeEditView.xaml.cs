﻿using CookBook.App.ViewModels;

namespace CookBook.App.Views.Recipe;

public partial class RecipeEditView : ContentPageBase
{
    public RecipeEditView(RecipeEditViewModel viewModel)
        : base(viewModel)
    {
        InitializeComponent();
    }
}
