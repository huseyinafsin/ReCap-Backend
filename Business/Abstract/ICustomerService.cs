using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using Entities.DTOs;
using System;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAllCustomers();
        IDataResult<List<CustomerDetailDto>> GetAllWithDetails();
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IDataResult<Customer> GetCustomerById(Guid customerId);
        int GetFindexScore(Guid customerId);
        IDataResult<CustomerDetailDto> GetDetailsByMail(string email);
    }
}
