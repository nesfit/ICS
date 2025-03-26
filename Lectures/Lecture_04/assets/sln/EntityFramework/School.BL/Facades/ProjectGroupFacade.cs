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
    public class ProjectGroupFacade : CrudFacadeBase<ProjectGroupEntity, ProjectGroupListModel, ProjectGroupDetailModel>
    {
        public ProjectGroupFacade(
            UnitOfWork unitOfWork, 
            RepositoryBase<ProjectGroupEntity> repository, 
            IMapper<ProjectGroupEntity, ProjectGroupListModel, ProjectGroupDetailModel> mapper, 
            IEntityFactory entityFactory) 
            : base(unitOfWork, repository, mapper, entityFactory)
        {
        }

        protected override Func<IQueryable<ProjectGroupEntity>, IIncludableQueryable<ProjectGroupEntity, object>>[] Includes { get; } = new Func<IQueryable<ProjectGroupEntity>, IIncludableQueryable<ProjectGroupEntity, object>>[]
        {
            entities => entities.Include(i=>i.Students)
        };
    }
}