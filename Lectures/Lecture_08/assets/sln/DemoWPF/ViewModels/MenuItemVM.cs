using System;
using HelloWPF.Models;

namespace HelloWPF.ViewModels
{
    public class MenuItemVm
    {
        private readonly MenuItem _menuItem;

        public MenuItemVm(MenuItem menuItem)
        {
            _menuItem = menuItem;
        }

        public String Title => _menuItem.Title;
        public String SubTitle => _menuItem.SubTitle;
    }
}