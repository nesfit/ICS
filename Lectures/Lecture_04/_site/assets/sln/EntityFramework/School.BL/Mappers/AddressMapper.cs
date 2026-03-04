using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Factories;
using School.BL.Models.DetailModels;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public class AddressMapper : IMapper<AddressEntity, AddressDetailModel, AddressDetailModel>
    {
        public IEnumerable<AddressDetailModel> Map(IQueryable<AddressEntity>? entities)
            => entities is null
                ? Enumerable.Empty<AddressDetailModel>().ToValueCollection()
                : entities.Select(entity => Map(entity)!).ToValueCollection();

        public AddressDetailModel? Map(AddressEntity? entity)
            => entity is null ? null : new AddressDetailModel
            {
                Id = entity.Id,
                City = entity.City ?? string.Empty,
                Street = entity.Street ?? string.Empty,
                State = entity.State ?? string.Empty,
                Country = entity.Country ?? string.Empty
            };

        public AddressEntity Map(AddressDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<AddressEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.City = detailModel.City;
            entity.Street = detailModel.Street;
            entity.State = detailModel.State;
            entity.Country = detailModel.Country;

            return entity;
        }
    }
}
