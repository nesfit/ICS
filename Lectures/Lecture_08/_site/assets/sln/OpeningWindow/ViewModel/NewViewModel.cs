using OpeningWindow.ViewModel.Base;

namespace OpeningWindow.ViewModel
{
    public class NewViewModel : ViewModelBase
    {
        private readonly WindowService windowService;
        private string text;

        public NewViewModel(WindowService windowService)
        {
            this.windowService = windowService;
            Text = "New window was opened successfully!";
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
    }
}