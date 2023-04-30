using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerDal: IRepository<Customer>
    {
        IQueryable<CustomerDetailDto> GetAllWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null);
        CustomerDetailDto GetWithDetails(Expression<Func<CustomerDetailDto, bool>> filter = null);
    }
}
