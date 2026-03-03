using System;
using System.Collections.Generic;
using System.Linq;
using School.BL.Factories;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public class StudentMapper : IMapper<StudentEntity, StudentListModel, StudentDetailModel>
    {
        public IMapper<AddressEntity, AddressDetailModel, AddressDetailModel> AddressMapper { get; set; } = new AddressMapper();

        public IEnumerable<StudentListModel> Map(IQueryable<StudentEntity>? entities)
        {
            return entities is null
                ? Enumerable.Empty<StudentListModel>().ToValueCollection()
                : entities.Select(entity => new StudentListModel
            {
                Id = entity.Id,
                Name = entity.Name ?? string.Empty
            }).ToValueCollection();
        }

        public StudentDetailModel? Map(StudentEntity? entity) => entity is null
            ? null
            : new StudentDetailModel
            {
                Id = entity.Id,
                Name = entity.Name ?? string.Empty,
                Address = AddressMapper.Map(entity.Address) ?? new AddressDetailModel
                {
                    Street = string.Empty,
                    City = string.Empty,
                    State = string.Empty,
                    Country = string.Empty
                },
                Courses = entity.StudentCourses.Select(
                    courseEntity => new StudentCourseListModel
                    {
                        Id = courseEntity.Id,
                        CourseId = courseEntity.CourseId,
                        StudentId = entity.Id,
                        Name = courseEntity.Course?.Name ?? string.Empty
                    }).ToValueCollection(),
                ProjectGroup = new ProjectGroupListModel
                {
                    Id = entity.ProjectGroup?.Id ?? Guid.Empty,
                    AvailableSpots = entity.ProjectGroup?.AvailableSpots
                }
            };

        public StudentEntity Map(StudentDetailModel detailModel, IEntityFactory entityFactory
            )
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<StudentEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.Name = detailModel.Name;
            
            entity.Address = AddressMapper.Map(detailModel.Address, entityFactory);

            entity.StudentCourses = detailModel.Courses.Select(course =>
            {
                var studentCourseEntity= entityFactory.Create<StudentCourseEntity>(course.Id);
                studentCourseEntity.CourseId = course.CourseId;
                studentCourseEntity.StudentId = detailModel.Id;
                return studentCourseEntity;
            }).ToValueCollection();

            entity.ProjectGroupId = detailModel.ProjectGroup.Id;

            return entity;
        }
    }
}
