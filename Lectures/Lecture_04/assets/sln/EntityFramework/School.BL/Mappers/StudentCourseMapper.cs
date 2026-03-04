using System.Collections.Generic;
using System.Linq;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class StudentCourseMapper 
    {
        public IEnumerable<StudentCourseListModel> Map(IEnumerable<StudentEntity>? entities)
            => entities is null
                ? Enumerable.Empty<StudentCourseListModel>().ToValueCollection()
                : entities.SelectMany(MapStudentCourse).ToValueCollection();

        public IEnumerable<StudentCourseListModel> MapStudentCourse(StudentEntity? studentEntity)
        {
            if (studentEntity is null)
            {
                return Enumerable.Empty<StudentCourseListModel>().ToValueCollection();
            }

            return studentEntity.StudentCourses.Select(courseEntity => new StudentCourseListModel
            {
                Id = courseEntity.Id,
                StudentId = courseEntity.StudentId,
                CourseId = courseEntity.CourseId,
                Name = studentEntity.Name ?? string.Empty
            }).ToValueCollection();
        }
    }
}
