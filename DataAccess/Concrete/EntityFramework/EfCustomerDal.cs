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

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : Repository<Customer>, ICustomerDal
    {
        public EfCustomerDal()
        {
        }

        public List<CustomerDetailDto> GetAllWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CustomerId = c.Id,
                        CompanyName = c.CompanyName,
                        FindexScore = c.FindexScore
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CustomerDetailDto GetWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CustomerId = c.Id,
                        CompanyName = c.CompanyName,
                        FindexScore = c.FindexScore
                    };
                return result.FirstOrDefault(filter);
            }
        }
    }
}
