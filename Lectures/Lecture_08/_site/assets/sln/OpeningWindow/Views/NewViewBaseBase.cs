namespace OpeningWindow.Views
{
    public class NewViewBaseBase : IViewBase
    {
        public void Show()
        {
            // Here can be switch for more options
            // i.e., Depends on application settings
            new NewView().Show();
        }
    }
}