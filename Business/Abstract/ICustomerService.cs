using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;
using System;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<List<Customer>>> GetAllCustomers();
        IDataResult<List<CustomerDetailDto>> GetAllWithDetails();
        Task<IResult> AddCustomer(Customer customer);
        Task<IResult> DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        Task<IDataResult<Customer>> GetCustomerById(Guid customerId);
        int GetFindexScore(Guid customerId);
        IDataResult<CustomerDetailDto> GetDetailsByMail(string email);
    }
}
