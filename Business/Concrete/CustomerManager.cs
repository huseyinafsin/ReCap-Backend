using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult AddCustomer(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult DeleteCustomer(Customer customer)
        {

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }


        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x=>x.Id==customerId), Messages.CustomerFetched);
        }


        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
