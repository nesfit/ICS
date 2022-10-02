using CookBook.BL.Facades;
using CookBook.DAL;
using CookBook.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.BL;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLServices(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
        services.AddSingleton<RecipeFacade>();
        services.AddSingleton<IngredientFacade>();

        services.AddAutoMapper((serviceProvider, cfg) =>
        {
            // TODO: remove this when AutoMapper is no longer needed
            //cfg.AddCollectionMappers();
            var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<CookBookDbContext>>();
            using var dbContext = dbContextFactory.CreateDbContext();
            
            //cfg.UseEntityFrameworkCoreModel<CookBookDbContext>(dbContext.Model);
        }, typeof(BusinessLogic).Assembly);
        return services;
    }
}