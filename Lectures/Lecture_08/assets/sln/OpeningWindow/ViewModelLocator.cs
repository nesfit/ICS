using OpeningWindow.ViewModel;

namespace OpeningWindow
{
    public class ViewModelLocator
    {
        private readonly WindowService windowService = new WindowService();

        public MainViewModel MainViewModel => CreateMainViewModel();
        public NewViewModel NewViewModel => CreateNewViewModel();

        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel(windowService);
        }

        private NewViewModel CreateNewViewModel()
        {
            return new NewViewModel(windowService);
        }
    }
}