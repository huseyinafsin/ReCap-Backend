using Business.Constants;
using Core.DataAccess;
using Core.Entities;
using Core.Services;
using Core.Utilities.Errors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity, new() 
    {
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IDataResult<TEntity> GetByIdAsync(Guid id)
        {
            var result =  _repository.Get(x => x.Id.Equals(id));

            if (result == null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name}({id}) not found");
            }

            return new SuccessDataResult<TEntity>(result, typeof(TEntity).Name + " " + Messages.EntityFetched);
        }


        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Where(expression);
        }

        public IDataResult<IEnumerable<TEntity>> GetAllAsync()
        {
            var result =  _repository.GetAll();
            return new SuccessDataResult<IEnumerable<TEntity>>(result, typeof(TEntity).Name + " " + Messages.EntityListed);

        }

        public IResult Any(Expression<Func<TEntity, bool>> expression)
        {
            var result =  _repository.Any(expression);
            if (result)
                return new SuccessResult();

            return new SuccessResult();

        }

        public IDataResult<TEntity> Add(TEntity entity)
        {
             _repository.Add(entity);

            return new SuccessDataResult<TEntity>(entity, typeof(TEntity).Name + " " + Messages.EntityAdded);
        }


        public IDataResult<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
             _repository.AddRange(entities);
            return new SuccessDataResult<IEnumerable<TEntity>>(entities, typeof(TEntity).Name + " " + Messages.EntityAdded);
        }

        public IDataResult<TEntity> Update(TEntity entity)
        {
            var result = _repository.Update(entity);
            return new SuccessDataResult<TEntity>(result, typeof(TEntity).Name + " " + Messages.EntityUpdated);
        }

        public IResult Remove(Guid id)
        {
            var entity =  _repository.Get(x => x.Id==id);
             _repository.Remove(entity);
            return new SuccessResult(typeof(TEntity).Name + " " + Messages.EntityDeleted);
        }

        public IResult RemoveRange(IEnumerable<TEntity> entities)
        {
             _repository.RemoveRange(entities);
            return new SuccessResult(typeof(TEntity).Name + " " + Messages.EntityDeleted);

        }

    }
}
