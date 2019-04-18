using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookBook.App.ViewModels
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Load() {}

        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}