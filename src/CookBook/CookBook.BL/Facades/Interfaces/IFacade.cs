using CookBook.BL.Models;
using CookBook.DAL.Entities;

namespace CookBook.BL.Facades;

public interface IFacade<TEntity, TListModel, TDetailModel>
    where TEntity : class, IEntity
    where TListModel : ModelBase
    where TDetailModel : ModelBase
{
    Task DeleteAsync(Guid id);
    Task<TDetailModel?> GetAsync(Guid id);
    Task<IEnumerable<TListModel>> GetAsync();
    Task<TDetailModel> SaveAsync(TDetailModel model);
}
