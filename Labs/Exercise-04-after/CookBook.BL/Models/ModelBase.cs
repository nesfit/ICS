using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookBook.BL.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}