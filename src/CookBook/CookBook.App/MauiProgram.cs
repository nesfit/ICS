using CookBook.App.Services;
using CookBook.App.Shells;
using CookBook.App.ViewModels;
using CookBook.App.Views;

namespace CookBook.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<AppShell>();

        builder.Services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
            .AsSelf()
            .WithTransientLifetime());

        builder.Services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<IViewModel>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        builder.Services.AddSingleton<IRoutingService, RoutingService>();

        var app = builder.Build();

        var routingService = app.Services.GetRequiredService<IRoutingService>();

        foreach (var route in routingService.Routes)
        {
            Routing.RegisterRoute(route.Route, route.ViewType);
        }

        return app;
    }
}