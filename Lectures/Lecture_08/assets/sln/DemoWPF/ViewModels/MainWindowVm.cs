using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelloWPF.Annotations;

namespace HelloWPF.ViewModels
{
    public class MainWindowVm : INotifyPropertyChanged
    {
        public MainWindowVm()
        {
            NavigationMenu = new MenuVm();
        }

        public MenuVm NavigationMenu { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}