using CommunityToolkit.Maui;
using CookBook.App.Options;
using CookBook.App.Services;
using CookBook.App.Shells;
using CookBook.App.ViewModels;
using CookBook.App.Views;
using CookBook.BL;
using CookBook.BL.Mappers;
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

        builder.Services.AddSingleton<IngredientEntityMapper>();
        builder.Services.AddSingleton<IngredientModelMapper>();

        builder.Services.AddSingleton<IngredientAmountMapper>();
        builder.Services.AddSingleton<RecipeModelMapper>();

        ConfigureAppSettings(builder);
        builder.Services.Configure<DALOptions>(options => builder.Configuration.GetSection("CookBook:DAL").Bind(options));

        builder.Services.AddSingleton<IDbContextFactory<CookBookDbContext>>(provider =>
        {
            var dalOptions = provider.GetRequiredService<IOptions<DALOptions>>().Value;
            return new SqlServerDbContextFactory(dalOptions.ConnectionString!, dalOptions.SkipMigrationAndSeedDemoData);
        });

        builder.Services.AddBLServices();

        var app = builder.Build();

        var routingService = app.Services.GetRequiredService<IRoutingService>();

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
        var appSettingsFilePath = "CookBook.App.appsettings.json";
        using var appSettingsStream = assembly.GetManifestResourceStream(appSettingsFilePath);
        configurationBuilder.AddJsonStream(appSettingsStream);

        var configuration = configurationBuilder.Build();
        builder.Configuration.AddConfiguration(configuration);
    }
}