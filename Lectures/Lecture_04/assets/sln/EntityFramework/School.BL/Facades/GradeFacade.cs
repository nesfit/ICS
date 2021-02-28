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
    public class GradeFacade : CrudFacadeBase<GradeEntity, GradeListModel, GradeDetailModel>
    {
        public GradeFacade(
            UnitOfWork unitOfWork, 
            RepositoryBase<GradeEntity> repository, 
            IMapper<GradeEntity, GradeListModel, GradeDetailModel> mapper, 
            IEntityFactory entityFactory) 
            : base(unitOfWork, repository, mapper, entityFactory)
        {
        }

        protected override Func<IQueryable<GradeEntity>, IIncludableQueryable<GradeEntity, object>>[] Includes { get; } = new Func<IQueryable<GradeEntity>, IIncludableQueryable<GradeEntity, object>>[]
        {
            entities => entities.Include(i=>i.Students)
        };
    }
}