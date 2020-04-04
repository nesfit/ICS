using System;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.App.Factories
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();

            services.AddSingleton<Func<TService>>(x => x.GetService<TService>);

            services.AddSingleton<IFactory<TService>, Factory<TService>>();
        }
    }
}