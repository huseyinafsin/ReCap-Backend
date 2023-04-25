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
        Task<IDataResult<TEntity>> GetByIdAsync(Guid id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<IResult> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<IDataResult<TEntity>> AddAsync(TEntity entity);
        Task<IDataResult<IEnumerable<TEntity>>> AddRangeAsync(IEnumerable<TEntity> entities);
        IDataResult<TEntity> Update(TEntity entity);
        Task<IResult> RemoveAsync(Guid id);
        Task<IResult> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
