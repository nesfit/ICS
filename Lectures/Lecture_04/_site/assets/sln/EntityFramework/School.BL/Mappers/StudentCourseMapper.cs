using System.Collections.Generic;
using System.Linq;
using School.BL.Models.ListModels;
using School.DAL.Entities;

namespace School.BL.Mappers
{
    public class StudentCourseMapper 
    {
        public IEnumerable<StudentCourseListModel> Map(IEnumerable<StudentEntity> entities) 
            => entities?.SelectMany(MapStudentCourse).ToValueCollection();

        public IEnumerable<StudentCourseListModel> MapStudentCourse(StudentEntity studentEntity)
        {
            return studentEntity?.StudentCourses.Select(courseEntity => new StudentCourseListModel()
            {
                Id = courseEntity.Id,
                StudentId = courseEntity.StudentId,
                CourseId = courseEntity.CourseId,
                Name = studentEntity.Name
            }).ToValueCollection();
        }
    }
}