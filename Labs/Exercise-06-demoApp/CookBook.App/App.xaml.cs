using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using CookBook.App.Services.MessageDialog;
using CookBook.App.ViewModels;
using CookBook.App.Views;
using CookBook.BL.Interfaces;
using CookBook.BL.Repositories;
using CookBook.BL.Services;
using CookBook.DAL.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CookBook.App
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");

            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"AppSettings.json", false, true);
        }

        private static void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<IIngredientRepository, IngredientRepository>();
            services.AddSingleton<IRecipeRepository, RecipeRepository>();

            services.AddSingleton<IMessageDialogService, MessageDialogService>();
            services.AddSingleton<IMediator, Mediator>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<IIngredientListViewModel, IngredientListViewModel>();
            services.AddSingleton<IIngredientDetailViewModel, IngredientDetailViewModel>();
            services.AddSingleton<IRecipeListViewModel, RecipeListViewModel>();
            services.AddSingleton<IRecipeDetailViewModel, RecipeDetailViewModel>();
            services.AddSingleton<IIngredientAmountDetailViewModel, IngredientAmountDetailViewModel>();

            services.AddSingleton<IDbContextFactory>(provider => new DbContextFactory(configuration.GetConnectionString("DefaultConnection")));
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var dbContextFactory = host.Services.GetRequiredService<IDbContextFactory>();

#if DEBUG
            await using (var dbx = dbContextFactory.CreateDbContext())
            {
                await dbx.Database.EnsureCreatedAsync();
            }
#endif

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}