using CommunityToolkit.Maui;
using CookBook.App.Options;
using CookBook.App.Services;
using CookBook.App.Shells;
using CookBook.App.ViewModels;
using CookBook.App.Views;
using CookBook.BL;
using CookBook.DAL;
using CookBook.DAL.Factories;
using CookBook.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CookBook.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient(_ => Shell.Current);

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

        builder.Services.AddTransient<INavigationService, NavigationService>();

        builder.Services.AddSingleton<IngredientEntityMapper>();
        builder.Services.AddSingleton<IngredientAmountEntityMapper>();
        builder.Services.AddSingleton<RecipeEntityMapper>();

        ConfigureAppSettings(builder);
        builder.Services.Configure<DALOptions>(options => builder.Configuration.GetSection("CookBook:DAL").Bind(options));

        builder.Services.AddSingleton<IDbContextFactory<CookBookDbContext>>(provider =>
        {
            var dalOptions = provider.GetRequiredService<IOptions<DALOptions>>().Value;
            return new SqlServerDbContextFactory(dalOptions.ConnectionString!, dalOptions.SkipMigrationAndSeedDemoData);
        });

        builder.Services.AddBLServices();

        var app = builder.Build();

        var routingService = app.Services.GetRequiredService<INavigationService>();

        foreach (var route in routingService.Routes)
        {
            Routing.RegisterRoute(route.Route, route.ViewType);
        }

        return app;
    }

    private static void ConfigureAppSettings(MauiAppBuilder builder)
    {
        var configurationBuilder = new ConfigurationBuilder();

        var assembly = Assembly.GetExecutingAssembly();
        const string appSettingsFilePath = "CookBook.App.appsettings.json";
        using var appSettingsStream = assembly.GetManifestResourceStream(appSettingsFilePath);
        if (appSettingsStream is not null)
        {
            configurationBuilder.AddJsonStream(appSettingsStream);
        }

        var configuration = configurationBuilder.Build();
        builder.Configuration.AddConfiguration(configuration);
    }
}