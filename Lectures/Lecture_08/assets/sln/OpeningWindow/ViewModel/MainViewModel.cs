using System.Windows.Input;
using OpeningWindow.ViewModel.Base;
using OpeningWindow.Views;

namespace OpeningWindow.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly WindowService windowService;
        private string text;

        public MainViewModel(WindowService windowService)
        {
            this.windowService = windowService;
            Text = "Open New Window";
            OpenWindowCommand = new RelayCommand(OpenWindow);
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenWindowCommand { get; set; }

        private void OpenWindow()
        {
            windowService.ShowWindow<NewViewBaseBase>();
        }
    }
}