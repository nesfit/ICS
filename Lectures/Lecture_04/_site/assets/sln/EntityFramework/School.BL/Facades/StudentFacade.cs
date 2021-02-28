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
    public class StudentFacade : CrudFacadeBase<StudentEntity, StudentListModel, StudentDetailModel>
    {
        public StudentFacade(
            UnitOfWork unitOfWork, 
            RepositoryBase<StudentEntity> repository, 
            IMapper<StudentEntity, StudentListModel, StudentDetailModel> mapper, 
            IEntityFactory entityFactory) 
            : base(unitOfWork, repository, mapper, entityFactory)
        {
        }

        protected override Func<IQueryable<StudentEntity>, IIncludableQueryable<StudentEntity, object>>[] Includes
        {
            get;
        } = new Func<IQueryable<StudentEntity>, IIncludableQueryable<StudentEntity, object>>[]
        {
            entities => entities.Include(i=>i.Address),
            entities => entities.Include(i=>i.Grade),
            entities => entities.Include(i=>i.StudentCourses)
                .ThenInclude(i=>i.Course),
        };
    }
}