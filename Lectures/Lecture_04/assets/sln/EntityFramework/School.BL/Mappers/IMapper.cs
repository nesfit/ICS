using System.Collections.Generic;
using System.Linq;
using School.BL.Models;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public interface IMapper<TEntity, out TListModel, TDetailModel>
        where TEntity : class, IEntity, new()
        where TListModel : IModel, new()
        where TDetailModel : IModel, new()
    {
        IEnumerable<TListModel> Map(IQueryable<TEntity> entities);
        TDetailModel Map(TEntity entity);
        TEntity Map(TDetailModel detailModel, IEntityFactory entityFactory);
    }
}