using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Mappers;

public interface IModelMapper<TEntity, TListModel, TDetailModel>
{
    TListModel MapToListModel(TEntity? entity);
    IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
        => entities.Select(MapToListModel);
    TDetailModel MapToDetailModel(TEntity entity);
    TEntity MapToEntity(TDetailModel model);
}