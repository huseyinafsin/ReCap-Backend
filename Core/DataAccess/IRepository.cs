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
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        bool Any(Expression<Func<TEntity, bool>> expression);
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
