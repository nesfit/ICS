using CookBook.App.Extensions;
using CookBook.App.Services;
using CookBook.App.Services.MessageDialog;
using CookBook.App.ViewModels;
using CookBook.App.Views;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace CookBook.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("cs");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("cs");

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"appsettings.json", false, true);
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
            services.AddFactory<IIngredientDetailViewModel, IngredientDetailViewModel>();
            services.AddSingleton<IRecipeListViewModel, RecipeListViewModel>();
            services.AddFactory<IRecipeDetailViewModel, RecipeDetailViewModel>();
            services.AddFactory<IIngredientAmountDetailViewModel, IngredientAmountDetailViewModel>();

            services.AddSingleton<INamedDbContextFactory<CookBookDbContext>>(provider => new SqlServerDbContextFactory(configuration.GetConnectionString("DefaultConnection")));

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var dbContextFactory = _host.Services.GetRequiredService<INamedDbContextFactory<CookBookDbContext>>();

#if DEBUG
            await using (var dbx = dbContextFactory.Create())
            {
                await dbx.Database.EnsureCreatedAsync();
            }
#endif

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
