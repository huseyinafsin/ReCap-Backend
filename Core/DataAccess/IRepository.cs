using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    public interface IRepository<TEntity> where TEntity : class,IEntity,new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
