using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Facades;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.Seeds;
using School.DAL.UnitOfWork;
using Xunit;

namespace School.BL.Tests
{
    public class StudentFacadeTests
    {
        private readonly StudentFacade _facadeSUT;
        private readonly RepositoryBase<StudentEntity> _repository;
        private readonly StudentMapper _mapper;

        public StudentFacadeTests()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(AddressFacadeTests));
            var dbx = dbContextFactory.Create();
            dbx.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(dbx);
            _repository = new RepositoryBase<StudentEntity>(unitOfWork);
            _mapper = new StudentMapper();
            var entityFactory = new EntityFactory(dbx.ChangeTracker);
            _facadeSUT = new StudentFacade(unitOfWork, _repository, _mapper, entityFactory);
        }

        [Fact]
        public void NewAddress_InsertOrUpdate_Persisted()
        {
            var detail = new StudentDetailModel()
            {
                Name = "Jane Doe",
                Address = new AddressDetailModel()
                {
                    City = "Brno",
                    Country = "Jihomoravsky-kraj",
                    State = "Czechia",
                    Street = "Bozetechova 2",
                },
                ProjectGroup = new ProjectGroupMapper().MapListModel(Seed.ProjectGroupJane),
                Courses = new List<StudentCourseListModel>()
                {
                    new()
                    {
                        CourseId = Seed.IcsCourse.Id,
                        Name = Seed.IcsCourse.Name,
                    }
                }
            };

            detail = _facadeSUT.Save(detail);

            Assert.NotEqual(Guid.Empty, detail.Id);

            var entityFromDb = _repository.GetById(detail.Id);
            Assert.Equal(detail, _mapper.Map(entityFromDb));
        }

        [Fact]
        public void GetById_Jane()
        {
            var detail = _facadeSUT.GetById(Seed.StudentJane.Id);

            Assert.Equal(detail, _mapper.Map(Seed.StudentJane));
        }
    }
}
