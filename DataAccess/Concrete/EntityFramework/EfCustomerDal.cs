using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : Repository<Customer>, ICustomerDal
    {
        public EfCustomerDal(DbContext context) : base(context)
        {
        }

        public IQueryable<CustomerDetailDto> GetAllWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            //using (ReCapContext context = new ReCapContext())
            //{
            //    var result = from c in context.Customers
            //        join u in context.Users
            //            on c.UserId equals u.Id
            //        select new CustomerDetailDto()
            //        {
            //            Email = u.Email,
            //            FirstName = u.FirstName,
            //            LastName = u.LastName,
            //            CustomerId = c.Id,
            //            CompanyName = c.CompanyName,
            //            FindexScore = c.FindexScore
            //        };
            //    return filter == null ? result.AsQueryable().AsNoTracking() : result.Where(filter).AsQueryable().AsNoTracking();
            //}
            throw new NotImplementedException();

        }

        public CustomerDetailDto GetWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            //using (ReCapContext context = new ReCapContext())
            //{
            //    var result = from c in context.Customers
            //        join u in context.Users
            //            on c.UserId equals u.Id
            //        select new CustomerDetailDto()
            //        {
            //            Email = u.Email,
            //            FirstName = u.FirstName,
            //            LastName = u.LastName,
            //            CustomerId = c.Id,
            //            CompanyName = c.CompanyName,
            //            FindexScore = c.FindexScore
            //        };
            //    return result.FirstOrDefault(filter);
            //}
            throw new NotImplementedException();

        }
    }
}
