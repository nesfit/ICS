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

        public IEnumerable<StudentListModel> Map(IQueryable<StudentEntity> entities)
        {
            return entities?.Select(entity => new StudentListModel()
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToArray();
        }

        public StudentDetailModel Map(StudentEntity entity) => entity == null
            ? null
            : new StudentDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = AddressMapper.Map(entity.Address),
                Courses = entity.StudentCourses.Select(
                    courseEntity => new StudentCourseListModel()
                    {
                        Id = courseEntity.Id,
                        CourseId = courseEntity.CourseId,
                        StudentId = entity.Id,
                        Name = courseEntity.Course.Name
                    }).ToArray(),
                Grade = new GradeListModel() { Id = entity.Grade.Id, Name = entity.Grade.Name}
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
            }).ToArray();

            entity.GradeId = detailModel.Grade.Id;

            return entity;
        }
    }

    public class StudentCourseMapper 
    {
        public IEnumerable<StudentCourseListModel> Map(IEnumerable<StudentEntity> entities) 
            => entities?.SelectMany(MapStudentCourse).ToArray();

        public IEnumerable<StudentCourseListModel> MapStudentCourse(StudentEntity studentEntity)
        {
            return studentEntity?.StudentCourses.Select(courseEntity => new StudentCourseListModel()
            {
                Id = courseEntity.Id,
                StudentId = courseEntity.StudentId,
                CourseId = courseEntity.CourseId,
                Name = studentEntity.Name
            }).ToArray();
        }
    }
}