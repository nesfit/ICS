using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HelloWPF.Annotations;
using HelloWPF.Models;

namespace HelloWPF.ViewModels
{
    public class MenuVm : INotifyPropertyChanged
    {
        private MenuItemVm _selectedItem;

        public MenuVm()
        {
            InitializeFakeMenuItems();
        }

        public ObservableCollection<MenuItemVm> MenuItems { get; } = new ObservableCollection<MenuItemVm>();

        public String SelectedTitle { get; set; }

        public MenuItemVm SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InitializeFakeMenuItems()
        {
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd1", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd2", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd3", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd4", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd5", SubTitle = "Lorem ipsum dolores sit amet"}));
            MenuItems.Add(new MenuItemVm(new MenuItem {Title = "abcd6", SubTitle = "Lorem ipsum dolores sit amet"}));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}