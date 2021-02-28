using System;
using System.Collections.Generic;
using System.Text;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.UnitOfWork;

namespace School.BL.Facades
{
    public class AddressFacade : CrudFacadeBase<AddressEntity, AddressDetailModel, AddressDetailModel>
    {
        public AddressFacade(UnitOfWork unitOfWork, 
            RepositoryBase<AddressEntity> repository, 
            IMapper<AddressEntity, AddressDetailModel, AddressDetailModel> mapper,
            IEntityFactory entityFactory) 
            : base(unitOfWork, repository, mapper, entityFactory)
        {
        }
    }
}
