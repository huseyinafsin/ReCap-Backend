using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class Repository<TEntity> :  IRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
             _dbSet.AddAsync(entity);
            try
            {
               _context.SaveChanges();
            }
            catch(Exception ex) { }
            return entity;
        }

        public  IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
             _dbSet.AddRange(entities);
             _context.SaveChanges();
            return entities;

        }


        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return  _dbSet.AnyAsync(expression).Result;
        }

        public  IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
            {
                return  _dbSet.Where(expression).AsQueryable().AsNoTracking();
            }
            return  _dbSet.AsQueryable().AsNoTracking();

        }

        public  TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return  _dbSet.FirstOrDefault(expression);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
             _context.SaveChanges();

        }

        public  void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
             _context.SaveChanges();

        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return _dbSet.AsQueryable();
            }
            return _dbSet.Where(expression).AsQueryable();
        }
    }
}
