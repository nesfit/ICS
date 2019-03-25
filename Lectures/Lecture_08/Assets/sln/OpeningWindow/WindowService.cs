using OpeningWindow.Views;

namespace OpeningWindow
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>() where T : class, IViewBase, new()
        {
            var window = new T();
            window.Show();
        }
    }
}