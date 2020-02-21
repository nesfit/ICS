using System;
using School.BL.Facades;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.UnitOfWork;
using Xunit;

namespace School.BL.Tests
{
    public class AddressFacadeTests
    {
        private readonly AddressFacade _facadeSUT;
        private readonly RepositoryBase<AddressEntity> _repository;
        private readonly AddressMapper _mapper;

        public AddressFacadeTests()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(AddressFacadeTests));
            var dbx = dbContextFactory.Create();
            dbx.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(dbx);
            _repository = new RepositoryBase<AddressEntity>(unitOfWork);
            _mapper = new AddressMapper();
            var entityFactory = new EntityFactory(dbx.ChangeTracker);
            _facadeSUT = new AddressFacade(unitOfWork,_repository, _mapper, entityFactory);
        }

        [Fact]
        public void NewAddress_InsertOrUpdate_Persisted()
        {
            var detail = new AddressDetailModel()
            {
                City = "Brno",
                Country = "Jihomoravsky-kraj",
                State = "Czechia",
                Street = "Bozetechova 2",
            };

            detail = _facadeSUT.Save(detail);

            Assert.NotEqual(Guid.Empty, detail.Id);

            var entityFromDb = _repository.GetById(detail.Id);
            Assert.Equal(detail, _mapper.Map(entityFromDb), AddressDetailModel.AddressDetailModelComparer);
        }
    }
}
