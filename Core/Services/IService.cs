using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<TEntity> where TEntity : class , IEntity { 
        IDataResult<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IDataResult<IEnumerable<TEntity>> GetAllAsync();
        IResult Any(Expression<Func<TEntity, bool>> expression);
        IDataResult<TEntity> Add(TEntity entity);
        IDataResult<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        IDataResult<TEntity> Update(TEntity entity);
        IResult Remove(Guid id);
        IResult RemoveRange(IEnumerable<TEntity> entities);
    }
}
