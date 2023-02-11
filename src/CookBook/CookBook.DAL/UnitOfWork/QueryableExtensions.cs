using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CookBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookBook.DAL.UnitOfWork;

public static class QueryableExtensions
{
    public static async Task PreLoadChangeTracker<TEntity>(this IQueryable<TEntity> dbSet, Guid entityId,
        IModel model, CancellationToken cancellationToken) where TEntity : class, IEntity
        => await dbSet
            .IncludeFirstLevelNavigationProperties(model)
            .Where(e => e.Id == entityId)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

    public static IQueryable<TEntity> IncludeFirstLevelNavigationProperties<TEntity>(this IQueryable<TEntity> query,
        IModel model) where TEntity : class
    {
        IEnumerable<INavigation>? navigationProperties = model.FindEntityType(typeof(TEntity))?.GetNavigations();
        if (navigationProperties == null)
        {
            return query;
        }

        foreach (INavigation navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty.Name);
        }

        return query;
    }
}
