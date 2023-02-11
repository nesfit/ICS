using CommunityToolkit.Mvvm.Messaging;
using CookBook.App.Services;
using CookBook.App.Shells;
using CookBook.App.ViewModels;
using CookBook.App.Views;
using CookBook.DAL.Mappers;

namespace CookBook.App;

public static class APPInstaller
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<AppShell>();

        services.AddSingleton<IMessenger>(_ => StrongReferenceMessenger.Default);
        services.AddSingleton<IMessengerService, MessengerService>();

        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
            .AsSelf()
            .WithTransientLifetime());

        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<IViewModel>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        services.AddTransient<INavigationService, NavigationService>();

        services.AddSingleton<IngredientEntityMapper>();
        services.AddSingleton<IngredientAmountEntityMapper>();
        services.AddSingleton<RecipeEntityMapper>();

        return services;
    }
}
