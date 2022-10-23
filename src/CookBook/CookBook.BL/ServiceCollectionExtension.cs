using CookBook.BL.Facades;
using CookBook.BL.Mappers;
using CookBook.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.BL;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddSingleton(typeof(IFacade<,,,>), typeof(Facade<,,,>));

        services.AddSingleton<IngredientAmountModelMapper>();

        services.Scan(selector => selector
            .FromAssemblyOf<BusinessLogic>()
            .AddClasses(filter => filter.AssignableTo(typeof(ModelMapperBase<,,>)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}