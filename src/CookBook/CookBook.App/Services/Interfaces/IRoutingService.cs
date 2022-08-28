using CookBook.App.Models;
using CookBook.App.ViewModels;

namespace CookBook.App.Services;

public interface IRoutingService
{
    IEnumerable<RouteModel> Routes { get; }

    string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel;
}