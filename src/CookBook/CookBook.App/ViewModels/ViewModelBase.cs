using CommunityToolkit.Mvvm.ComponentModel;

namespace CookBook.App.ViewModels
{
    [INotifyPropertyChanged]
    public abstract partial class ViewModelBase : IViewModel
    {
        public virtual Task OnAppearingAsync()
        {
            return Task.CompletedTask;
        }
    }
}