using System.Collections.Generic;
using System.Linq;
using School.BL.Factories;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public class CourseMapper : IMapper<CourseEntity, CourseListModel, CourseDetailModel>
    {
        public IMapper<StudentEntity, StudentListModel, StudentDetailModel> StudentMapper { get; set; } 

        public StudentCourseMapper StudentCourseMapper { get; set; } = new();

        public IEnumerable<CourseListModel> Map(IQueryable<CourseEntity> entities) 
            => entities?.Select(entity => new CourseListModel()
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToValueCollection();

        public CourseDetailModel Map(CourseEntity entity) 
            => entity is null
                ? null
                : new CourseDetailModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Students = StudentCourseMapper.Map(entity.StudentCourses.Select(i=>i.Student)).ToValueCollection()
                };

        public CourseEntity Map(CourseDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<CourseEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.Name = detailModel.Name;
            entity.Description = detailModel.Description;
            entity.StudentCourses = detailModel.Students.Select(model =>
            {
                var studentCourseEntity = entityFactory.Create<StudentCourseEntity>(model.CourseId);
                studentCourseEntity.CourseId = detailModel.Id;
                studentCourseEntity.StudentId = model.StudentId;
                return studentCourseEntity;
            }).ToValueCollection();
            return entity;
        }
    }
}