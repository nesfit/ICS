using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using School.BL.Facades;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.Seeds;
using School.DAL.UnitOfWork;
using Xunit;

namespace School.BL.Tests
{
    public sealed class StudentFacadeTests : IAsyncLifetime
    {
        private DbContextInMemoryFactory? _dbContextFactory;
        private UnitOfWork? _unitOfWork;
        private StudentFacade? _facadeSut;

        private StudentFacade FacadeSut
            => _facadeSut ?? throw new InvalidOperationException("Test facade is not initialized.");

        public Task InitializeAsync()
        {
            _dbContextFactory = new DbContextInMemoryFactory($"{nameof(StudentFacadeTests)}-{Guid.NewGuid()}");
            using var dbx = _dbContextFactory.Create();
            _ = dbx.Database.EnsureCreated();
            _facadeSut = CreateFacade(out var unitOfWork);
            _unitOfWork = unitOfWork;

            return Task.CompletedTask;
        }

        [Fact]
        public void Save_NewStudent_PersistsEntityWithAddressAndCourses()
        {
            var detail = new StudentDetailModel
            {
                Name = "Jane Doe",
                Address = new AddressDetailModel
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
                        Name = Seed.IcsCourse.Name ?? string.Empty,
                    }
                }
            };

            detail = FacadeSut.Save(detail);

            var loaded = UseFreshFacade(f => f.GetById(detail.Id));

            loaded.Should().BeEquivalentTo(
                detail,
                options => options
                    .Including(d => d.Id)
                    .Including(d => d.Name)
                    .Including(d => d.Address.Street)
                    .Including(d => d.Address.City)
                    .Including(d => d.Address.State)
                    .Including(d => d.Address.Country)
                    .Including(d => d.ProjectGroup.Id)
                    .Including(d => d.Courses));

            var persisted = UseFreshDbContext(db => db.Students
                .Include(s => s.Address)
                .Include(s => s.StudentCourses)
                .SingleOrDefault(s => s.Id == detail.Id));

            persisted.Should().NotBeNull();
            persisted!.Name.Should().Be(detail.Name);
            persisted.Address.Should().NotBeNull();
            persisted.Address!.City.Should().Be(detail.Address.City);
            persisted.StudentCourses.Select(c => c.CourseId).Should().Contain(Seed.IcsCourse.Id);
        }

        [Fact]
        public void GetById_ExistingSeedStudent_ReturnsMappedDetail()
        {
            var detail = FacadeSut.GetById(Seed.StudentJane.Id);

            new
            {
                detail!.Id,
                detail.Name,
                AddressCity = detail.Address.City,
                ProjectGroupId = detail.ProjectGroup.Id
            }.Should().BeEquivalentTo(
                new
                {
                    Id = Seed.StudentJane.Id,
                    Name = Seed.StudentJane.Name,
                    AddressCity = Seed.AddressJane.City,
                    ProjectGroupId = Seed.ProjectGroupJane.Id
                });
        }

        [Fact]
        public void GetById_NonExistingStudent_ReturnsNull()
        {
            var detail = FacadeSut.GetById(Guid.NewGuid());

            detail.Should().BeNull();
        }

        [Fact]
        public void Save_ExistingStudent_UpdatesPersistedValues()
        {
            var original = FacadeSut.GetById(Seed.StudentJane.Id);
            Assert.NotNull(original);

            original!.Name = "Jane Updated";
            original.Address.City = "Brno";
            original.Courses = new List<StudentCourseListModel>
            {
                new()
                {
                    Id = Seed.StudentCourseJane.Id,
                    CourseId = Seed.IcsCourse.Id,
                    StudentId = Seed.StudentJane.Id,
                    Name = Seed.IcsCourse.Name
                }
            };

            var updated = FacadeSut.Save(original);

            new
            {
                updated.Name,
                AddressCity = updated.Address.City,
                Courses = updated.Courses.Select(c => c.CourseId).OrderBy(i => i).ToArray()
            }.Should().BeEquivalentTo(
                new
                {
                    Name = "Jane Updated",
                    AddressCity = "Brno",
                    Courses = new[] { Seed.IcsCourse.Id }
                });

            var persisted = UseFreshDbContext(db => db.Students
                .Include(s => s.Address)
                .Include(s => s.StudentCourses)
                .SingleOrDefault(s => s.Id == Seed.StudentJane.Id));

            persisted.Should().NotBeNull();
            persisted!.Name.Should().Be("Jane Updated");
            persisted.Address!.City.Should().Be("Brno");
            persisted.StudentCourses.Select(c => c.CourseId).Should().Equal(Seed.IcsCourse.Id);
        }

        [Fact]
        public void Delete_ExistingStudent_RemovesEntity()
        {
            var created = FacadeSut.Save(new StudentDetailModel
            {
                Name = "Delete candidate",
                Address = new AddressDetailModel
                {
                    Street = "Kolejni 1",
                    City = "Brno",
                    State = "Czechia",
                    Country = "JMK"
                },
                ProjectGroup = new ProjectGroupMapper().MapListModel(Seed.ProjectGroupJane),
                Courses = new List<StudentCourseListModel>()
            });

            UseFreshFacade(f => f.Delete(created.Id));

            var deleted = UseFreshFacade(f => f.GetById(created.Id));
            deleted.Should().BeNull();

            var persisted = UseFreshDbContext(db => db.Students.SingleOrDefault(s => s.Id == created.Id));
            persisted.Should().BeNull();
        }

        [Fact]
        public void Delete_ByDetailModel_RemovesEntity()
        {
            var created = FacadeSut.Save(new StudentDetailModel
            {
                Name = "Delete by detail",
                Address = new AddressDetailModel
                {
                    Street = "Kolejni 3",
                    City = "Brno",
                    State = "Czechia",
                    Country = "JMK"
                },
                ProjectGroup = new ProjectGroupMapper().MapListModel(Seed.ProjectGroupJane),
                Courses = new List<StudentCourseListModel>()
            });

            UseFreshFacade(f => f.Delete(created));

            var deleted = UseFreshFacade(f => f.GetById(created.Id));
            deleted.Should().BeNull();

            var persisted = UseFreshDbContext(db => db.Students.SingleOrDefault(s => s.Id == created.Id));
            persisted.Should().BeNull();
        }

        [Fact]
        public void Delete_ByListModel_RemovesEntity()
        {
            var created = FacadeSut.Save(new StudentDetailModel
            {
                Name = "Delete by list",
                Address = new AddressDetailModel
                {
                    Street = "Kolejni 4",
                    City = "Brno",
                    State = "Czechia",
                    Country = "JMK"
                },
                ProjectGroup = new ProjectGroupMapper().MapListModel(Seed.ProjectGroupJane),
                Courses = new List<StudentCourseListModel>()
            });

            var listModel = new StudentListModel
            {
                Id = created.Id,
                Name = created.Name
            };

            UseFreshFacade(f => f.Delete(listModel));

            var deleted = UseFreshFacade(f => f.GetById(created.Id));
            deleted.Should().BeNull();

            var persisted = UseFreshDbContext(db => db.Students.SingleOrDefault(s => s.Id == created.Id));
            persisted.Should().BeNull();
        }

        [Fact]
        public void GetAllList_AfterInsert_ContainsCreatedStudent()
        {
            var created = FacadeSut.Save(new StudentDetailModel
            {
                Name = "List candidate",
                Address = new AddressDetailModel
                {
                    Street = "Kolejni 2",
                    City = "Brno",
                    State = "Czechia",
                    Country = "JMK"
                },
                ProjectGroup = new ProjectGroupMapper().MapListModel(Seed.ProjectGroupJane),
                Courses = new List<StudentCourseListModel>()
            });

            var students = FacadeSut.GetAllList().ToList();

            students.Should().Contain(s => s.Id == created.Id && s.Name == "List candidate");
        }

        private void UseFreshFacade(Action<StudentFacade> action)
        {
            var facade = CreateFacade(out var unitOfWork);
            using (unitOfWork)
            {
                action(facade);
            }
        }

        private TResult UseFreshFacade<TResult>(Func<StudentFacade, TResult> action)
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

        private StudentFacade CreateFacade(out UnitOfWork unitOfWork)
        {
            var context = (_dbContextFactory ?? throw new InvalidOperationException("Test factory is not initialized.")).Create();
            unitOfWork = new UnitOfWork(context);
            var repository = new RepositoryBase<StudentEntity>(unitOfWork);
            var mapper = new StudentMapper();
            var entityFactory = new EntityFactory(context.ChangeTracker);
            return new StudentFacade(unitOfWork, repository, mapper, entityFactory);
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
