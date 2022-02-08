using CookBook.App.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CookBook.App.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();

            services.AddSingleton<Func<TService>>(x => x.GetRequiredService<TService>);

            services.AddSingleton<IFactory<TService>, Factory<TService>>();
        }
    }
}