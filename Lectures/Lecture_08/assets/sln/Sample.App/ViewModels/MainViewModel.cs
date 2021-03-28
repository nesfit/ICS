using System.Windows.Input;
using Sample.App.Commands;
using Sample.App.ViewModels.Base;

namespace Sample.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string leftText;
        private string rightText;

        public MainViewModel()
        {
            WriteLeftWithCanExecuteCommand = new RelayCommand(WriteLeftText, CanWriteLeftText);
            WriteLeftWithoutCanExecuteCommand = new RelayCommand(WriteLeftText);
            WriteRightWithCanExecuteCommand = new WriteRightWithCanExecuteCommand(this);
            WriteRightWithoutCanExecuteCommand = new WriteRightWithoutCanExecuteCommand(this);

            LeftText = "Relay Command Sample";
            RightText = "Command Class Sample";
        }

        public string LeftText
        {
            get => leftText;
            set
            {
                leftText = value;
                OnPropertyChanged();
            }
        }

        public string RightText
        {
            get => rightText;
            set
            {
                rightText = value;
                OnPropertyChanged();
            }
        }

        public ICommand WriteLeftWithCanExecuteCommand { get; set; }
        public ICommand WriteLeftWithoutCanExecuteCommand { get; set; }
        public ICommand WriteRightWithCanExecuteCommand { get; set; }
        public ICommand WriteRightWithoutCanExecuteCommand { get; set; }

        private void WriteLeftText(object parameter)
        {
            LeftText = parameter as string;
        }

        private bool CanWriteLeftText(object parameter)
        {
            return !string.IsNullOrEmpty(parameter as string);
        }
    }
}