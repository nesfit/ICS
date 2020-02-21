using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        protected override Func<IQueryable<CourseEntity>, IIncludableQueryable<CourseEntity, object>>[] Includes
        {
            get;
        } = new Func<IQueryable<CourseEntity>, IIncludableQueryable<CourseEntity, object>>[]
        {
            entities => entities.Include(i=>i.StudentCourses)
        };
    }
}