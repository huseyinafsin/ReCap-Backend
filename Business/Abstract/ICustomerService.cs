using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<IQueryable<Customer>> GetAllCustomers();
        IDataResult<IQueryable<CustomerDetailDto>> GetAllWithDetails();
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IDataResult<Customer> GetCustomerById(Guid customerId);
        int GetFindexScore(Guid customerId);
        IDataResult<CustomerDetailDto> GetDetailsByMail(string email);
    }
}
