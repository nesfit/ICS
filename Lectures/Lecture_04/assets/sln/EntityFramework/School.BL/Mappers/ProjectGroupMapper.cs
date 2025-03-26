using System.Collections.Generic;
using System.Linq;
using School.BL.Factories;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public class ProjectGroupMapper : IMapper<ProjectGroupEntity, ProjectGroupListModel, ProjectGroupDetailModel>
    {
        public IMapper<StudentEntity, StudentListModel, StudentDetailModel> StudentMapper { get; set; }

        public IEnumerable<ProjectGroupListModel> Map(IQueryable<ProjectGroupEntity> entities) 
            => entities?.Select(entity => MapListModel(entity)).ToValueCollection();

        public ProjectGroupListModel MapListModel(ProjectGroupEntity entity) =>
            new()
            {
                Id = entity.Id,
                AvailableSpots = entity.AvailableSpots,
            };

        public ProjectGroupDetailModel Map(ProjectGroupEntity entity) 
            => entity is null
            ? null
            : new ProjectGroupDetailModel
            {
                Id = entity.Id,
                MaxCapacity = entity.MaxCapacity,
                AvailableSpots = entity.AvailableSpots,
                Students = StudentMapper.Map(entity.Students.AsQueryable()).ToValueCollection()
            };

        public ProjectGroupEntity Map(ProjectGroupDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<ProjectGroupEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.AvailableSpots = detailModel.AvailableSpots;
            entity.MaxCapacity = detailModel.MaxCapacity;
            //entity.Students //We do not allow modification this way!
            return entity;
        }
    }
}