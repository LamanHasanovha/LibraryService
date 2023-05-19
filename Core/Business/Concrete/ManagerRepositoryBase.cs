using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business.Abstract;
using Core.Constants;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using Core.Features.Results.Abstract;
using Core.Features.Results.Concrete;
using FluentValidation;

namespace Core.Business.Concrete
{
    public class ManagerRepositoryBase<TEntity, TRepository> : IServiceRepository<TEntity>, IAsyncServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TRepository : class, IExtendedRepository<TEntity>
    {
        public readonly TRepository Repository;
        private IValidator _validator;

        public ManagerRepositoryBase(TRepository repository)
        {
            Repository = repository;
        }

        protected void SetValidator(IValidator validator)
        {
            _validator = validator;
        }


        #region Sync

        [CacheRemoveAspect("get")]
        public virtual TEntity Add(TEntity entity)
        {
            if(_validator is not null)
                ValidationTool.Validate(_validator, entity);
            return Repository.Add(entity);
        }

        [CacheRemoveAspect("get")]
        public virtual TEntity Delete(TEntity entity) => Repository.Delete(entity);

        [CacheRemoveAspect("get")]
        public virtual void DeleteAll() => Repository.DeleteAll();

        [CacheAspect]
        public virtual TEntity Get(int id) => Repository.Get(e => e.Id == id);

        [CacheAspect]
        public virtual List<TEntity> GetAll() => Repository.GetAll();

        [CacheRemoveAspect("get")]
        public virtual TEntity Update(TEntity entity)
        {
            if(_validator is not null)
                ValidationTool.Validate(_validator, entity);
            return Repository.Update(entity);
        }

        #endregion

        #region Async

        //[CacheRemoveAspect("get")]
        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            if (_validator is not null)
                ValidationTool.Validate(_validator, entity);
            return await Repository.AddAsync(entity);
        }

        //[CacheRemoveAspect("get")]
        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (_validator is not null)
                ValidationTool.Validate(_validator, entity);
            return await Repository.UpdateAsync(entity);
        }


        //[CacheRemoveAspect("get")]
        public async virtual Task<TEntity> DeleteAsync(TEntity entity) => await Repository.DeleteAsync(entity);

        //[CacheRemoveAspect("get")]
        public async virtual Task DeleteAllAsync() => await Repository.DeleteAllAsync();

        //[CacheAspect]
        public async virtual Task<List<TEntity>> GetAllAsync() => await Repository.GetAllAsync();

        //[CacheAspect]
        public async virtual Task<TEntity> GetAsync(int id) => await Repository.GetAsync(e => e.Id == id);

        #endregion
    }
}
