using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<List<CustomerDetailDto>> GetAllWithDetails();
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IDataResult<Customer> GetCustomerById(int customerId);
        IDataResult<CustomerDetailDto> GetDetailsByMail(string email);
    }
}
