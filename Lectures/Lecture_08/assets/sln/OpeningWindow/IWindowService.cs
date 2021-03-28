using OpeningWindow.Views;

namespace OpeningWindow
{
    public interface IWindowService
    {
        void ShowWindow<T>() where T : class, IViewBase, new();
    }
}