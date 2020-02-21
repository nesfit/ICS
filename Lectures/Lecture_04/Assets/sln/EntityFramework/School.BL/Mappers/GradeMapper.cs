using System.Collections.Generic;
using System.Linq;
using School.BL.Factories;
using School.BL.Models.DetailModels;
using School.BL.Models.ListModels;
using School.DAL.Entities;
using School.DAL.Factories;

namespace School.BL.Mappers
{
    public class GradeMapper : IMapper<GradeEntity, GradeListModel, GradeDetailModel>
    {
        public IMapper<StudentEntity, StudentListModel, StudentDetailModel> StudentMapper { get; set; }

        public IEnumerable<GradeListModel> Map(IQueryable<GradeEntity> entities) 
            => entities?.Select(entity => MapListModel(entity)).ToArray();

        public GradeListModel MapListModel(GradeEntity entity) =>
            new GradeListModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

        public GradeDetailModel Map(GradeEntity entity) 
            => entity == null
            ? null
            : new GradeDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Section = entity.Section,
                Students = StudentMapper.Map(entity.Students.AsQueryable()).ToList()
            };

        public GradeEntity Map(GradeDetailModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new CreateNewEntityFactory()).Create<GradeEntity>(detailModel.Id);

            entity.Id = detailModel.Id;
            entity.Name = detailModel.Name;
            entity.Section = detailModel.Section;
            //entity.Students //We do not allow modification this way!
            return entity;
        }
    }
}