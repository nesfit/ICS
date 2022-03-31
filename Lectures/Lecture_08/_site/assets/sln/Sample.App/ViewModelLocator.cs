using Sample.App.ViewModels;

namespace Sample.App
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => CreateMainViewModel();

        private MainViewModel CreateMainViewModel()
        {
            return new MainViewModel();
        }
    }
}