using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using School.BL.Facades;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.DAL;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.Seeds;
using School.DAL.UnitOfWork;
using Xunit;

namespace School.BL.Tests
{
    public sealed class AddressFacadeTests : IAsyncLifetime
    {
        private DbContextInMemoryFactory? _dbContextFactory;
        private UnitOfWork? _unitOfWork;
        private AddressFacade? _facadeSut;

        private AddressFacade FacadeSut
            => _facadeSut ?? throw new InvalidOperationException("Test facade is not initialized.");

        public Task InitializeAsync()
        {
            _dbContextFactory = new DbContextInMemoryFactory($"{nameof(AddressFacadeTests)}-{Guid.NewGuid()}");
            using var dbx = _dbContextFactory.Create();
            _ = dbx.Database.EnsureCreated();
            _facadeSut = CreateFacade(out var unitOfWork);
            _unitOfWork = unitOfWork;

            return Task.CompletedTask;
        }

        [Fact]
        public void Save_NewAddress_PersistsEntity()
        {
            var detail = new AddressDetailModel
            {
                City = "Brno",
                Country = "Jihomoravsky-kraj",
                State = "Czechia",
                Street = "Bozetechova 2",
            };

            detail = FacadeSut.Save(detail);

            var loaded = UseFreshFacade(f => f.GetById(detail.Id));
            loaded.Should().BeEquivalentTo(
                detail,
                options => options
                    .Including(d => d.Id)
                    .Including(d => d.City)
                    .Including(d => d.Street)
                    .Including(d => d.State)
                    .Including(d => d.Country));

            var persisted = UseFreshDbContext(db => db.Addresses.SingleOrDefault(a => a.Id == detail.Id));
            persisted.Should().NotBeNull();
            persisted!.City.Should().Be(detail.City);
            persisted.Street.Should().Be(detail.Street);
            persisted.State.Should().Be(detail.State);
            persisted.Country.Should().Be(detail.Country);
        }

        [Fact]
        public void GetById_ExistingSeedAddress_ReturnsMappedDetail()
        {
            var detail = FacadeSut.GetById(Seed.AddressJane.Id);

            new
            {
                detail!.Id,
                detail.City,
                detail.Street,
                detail.State,
                detail.Country
            }.Should().BeEquivalentTo(
                new
                {
                    Id = Seed.AddressJane.Id,
                    Seed.AddressJane.City,
                    Seed.AddressJane.Street,
                    Seed.AddressJane.State,
                    Seed.AddressJane.Country
                });
        }

        [Fact]
        public void GetById_NonExistingAddress_ReturnsNull()
        {
            var detail = FacadeSut.GetById(Guid.NewGuid());

            detail.Should().BeNull();
        }

        [Fact]
        public void Save_ExistingAddress_UpdatesPersistedValues()
        {
            var original = FacadeSut.GetById(Seed.AddressJane.Id);
            Assert.NotNull(original);

            original!.City = "Brno";
            original.Street = "Technicka 10";

            var updated = FacadeSut.Save(original);

            new
            {
                updated.City,
                updated.Street,
                updated.State,
                updated.Country
            }.Should().BeEquivalentTo(
                new
                {
                    City = "Brno",
                    Street = "Technicka 10",
                    Seed.AddressJane.State,
                    Seed.AddressJane.Country
                });

            var persisted = UseFreshDbContext(db => db.Addresses.SingleOrDefault(a => a.Id == Seed.AddressJane.Id));
            persisted.Should().NotBeNull();
            persisted!.City.Should().Be("Brno");
            persisted.Street.Should().Be("Technicka 10");
        }

        [Fact]
        public void Delete_ExistingAddress_RemovesEntity()
        {
            var created = FacadeSut.Save(new AddressDetailModel
            {
                City = "Brno",
                Country = "Czechia",
                State = "JMK",
                Street = "Delete candidate street"
            });

            UseFreshFacade(f => f.Delete(created.Id));

            var deleted = UseFreshFacade(f => f.GetById(created.Id));
            deleted.Should().BeNull();

            var persisted = UseFreshDbContext(db => db.Addresses.SingleOrDefault(a => a.Id == created.Id));
            persisted.Should().BeNull();
        }

        [Fact]
        public void GetAllList_AfterInsert_ContainsCreatedAddress()
        {
            var created = FacadeSut.Save(new AddressDetailModel
            {
                City = "Brno",
                Country = "Czechia",
                State = "JMK",
                Street = "List candidate street"
            });

            var addresses = FacadeSut.GetAllList().ToList();

            addresses.Should().Contain(a => a.Id == created.Id && a.Street == "List candidate street");
        }

        private void UseFreshFacade(Action<AddressFacade> action)
        {
            var facade = CreateFacade(out var unitOfWork);
            using (unitOfWork)
            {
                action(facade);
            }
        }

        private TResult UseFreshFacade<TResult>(Func<AddressFacade, TResult> action)
        {
            var facade = CreateFacade(out var unitOfWork);
            using (unitOfWork)
            {
                return action(facade);
            }
        }

        private TResult UseFreshDbContext<TResult>(Func<SchoolDbContext, TResult> action)
        {
            var context = (_dbContextFactory ?? throw new InvalidOperationException("Test factory is not initialized.")).Create();
            using (context)
            {
                return action(context);
            }
        }

        private AddressFacade CreateFacade(out UnitOfWork unitOfWork)
        {
            var context = (_dbContextFactory ?? throw new InvalidOperationException("Test factory is not initialized.")).Create();
            unitOfWork = new UnitOfWork(context);
            var repository = new RepositoryBase<AddressEntity>(unitOfWork);
            var mapper = new AddressMapper();
            var entityFactory = new EntityFactory(context.ChangeTracker);
            return new AddressFacade(unitOfWork, repository, mapper, entityFactory);
        }

        public Task DisposeAsync()
        {
            _unitOfWork?.Dispose();
            _unitOfWork = null;
            _facadeSut = null;
            _dbContextFactory = null;
            return Task.CompletedTask;
        }
    }
}
