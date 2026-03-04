using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using School.BL.Mappers;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.UnitOfWork;

namespace School.BL.Facades
{
    public class CourseFacade : CrudFacadeBase<CourseEntity, CourseListModel, CourseDetailModel>
    {
        public CourseFacade(
            UnitOfWork unitOfWork, 
            RepositoryBase<CourseEntity> repository,
            IMapper<CourseEntity, CourseListModel, CourseDetailModel> mapper, 
            IEntityFactory entityFactory) 
            : base(unitOfWork, repository, mapper, entityFactory)
        {
        }

        protected override Func<IQueryable<CourseEntity>, IQueryable<CourseEntity>>[] Includes
        {
            get;
        } = new Func<IQueryable<CourseEntity>, IQueryable<CourseEntity>>[]
        {
            entities => entities.Include(i=>i.StudentCourses)
        };
    }
}
