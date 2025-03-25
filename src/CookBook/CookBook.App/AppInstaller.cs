using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Extensions;
using CookBook.App.Services;
using CookBook.App.Shells;

namespace CookBook.App;

public static class AppInstaller
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<AppShell>();

        services.AddSingleton<IMessenger>(_ => WeakReferenceMessenger.Default);

        services.AddSingleton<IMessengerService, MessengerService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IAlertService, AlertService>();

        services.AddViews();
        services.AddViewModels();
        

        return services;
    }
}
