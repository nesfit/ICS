using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using School.BL.Mappers;
using School.BL.Models;
using School.DAL.Entities;
using School.DAL.Factories;
using School.DAL.Repositories;
using School.DAL.UnitOfWork;

namespace School.BL.Facades
{
    public abstract class CrudFacadeBase<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity, new()
        where TListModel : IModel, new()
        where TDetailModel : IModel, new()
    {
        private readonly IMapper<TEntity, TListModel, TDetailModel> _mapper;
        private readonly IEntityFactory _entityFactory;
        private readonly RepositoryBase<TEntity> _repository;
        private readonly UnitOfWork _unitOfWork;

        protected CrudFacadeBase(
            UnitOfWork unitOfWork,
            RepositoryBase<TEntity> repository,
            IMapper<TEntity, TListModel, TDetailModel> mapper,
            IEntityFactory entityFactory)
        {
            _mapper = mapper;
            _entityFactory = entityFactory;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] Includes { get; } = { };
        
        public IEnumerable<TListModel> GetAllList() => _mapper.Map(_repository.GetAll());

        public TDetailModel GetById(Guid id)
        {
            var query = _repository.GetAll();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var include in Includes)
            {
                query = include(query);
            } 

            return _mapper
                .Map(query.SingleOrDefault(i => i.Id.Equals(id)));
        }

        public void Delete(Guid id)
        {
            _repository.DeleteById(id);
            _unitOfWork.Commit();
        }

        public void Delete(TListModel model) => Delete(model.Id);

        public void Delete(TDetailModel model) => Delete(model.Id);

        public TDetailModel Save(TDetailModel model)
        {
            var _ = GetById(model.Id); //To fill the DbContext Identity Cache

            var entity = _mapper.Map(model, _entityFactory);
            entity = _repository.InsertOrUpdate(entity);
            _unitOfWork.Commit();

            return GetById(entity.Id); //To fill properties not mapped from model to entity
        }
    }
}