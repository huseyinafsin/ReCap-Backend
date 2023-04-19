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
using Core.Utilities.Business;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public CustomerManager(ICustomerDal customerDal, IUserService userService, IAuthService authService)
        {
            _customerDal = customerDal;
            _userService = userService;
            _authService = authService;
        }

        [CacheAspect()]
        [SecuredOperation("admin")]
        public IDataResult<List<CustomerDetailDto>> GetAllWithDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetAllWithDetails(), Messages.CustomerListed);

        }

        [CacheRemoveAspect("ICustomerService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerDtoValidator))]
        public IResult AddCustomer(Customer customer)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdValid(customer.UserId), CheckIfUserIdExist(customer.UserId));
            if (rulesResult != null)
            {
                return new ErrorResult( rulesResult.Message);
            }

            _customerDal.Add(customer);
            var result = _customerDal.Get(c => c.UserId == customer.UserId && c.CompanyName == customer.CompanyName);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.CustomerAdded);
            }

            return new ErrorResult( Messages.NotAddedCustomer);

        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        //[ValidationAspect(typeof(CustomerValidator))]
        public IResult DeleteCustomer(Customer customer)
        {

            var rulesResult = BusinessRules.Run(CheckIfCustomerIdExist(customer.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedCustomer = _customerDal.Get(c => c.Id == customer.Id);
            _customerDal.Delete(deletedCustomer);
            return new SuccessResult(Messages.CustomerDeleted);
        }


        [CacheAspect(10)]
        [SecuredOperation("admin")]
        public IDataResult<List<Customer>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public IDataResult<Customer> GetCustomerById(Guid customerId)
        {
            var result = _customerDal.Get(c => c.Id == customerId);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.CustomerListed);
            }

            return new ErrorDataResult<Customer>(null, Messages.CustomerNotExist);
        }

        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public IDataResult<CustomerDetailDto> GetDetailsByMail(string email)
        {
            var result = _customerDal.GetWithDetails(c => c.Email == email);
            if (result != null)
            {
                return new SuccessDataResult<CustomerDetailDto>(result, Messages.CustomerListed);
            }

            return new ErrorDataResult<CustomerDetailDto>(null, Messages.CustomerNotExist);
        }

        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public IDataResult<CustomerDetailDto> GetWithDetails(Guid customerId)
        {
            var result = _customerDal.GetWithDetails(c=>c.CustomerId==customerId);
            if (result != null)
            {
                return new SuccessDataResult<CustomerDetailDto>(result, Messages.CustomerListed);
            }

            return new ErrorDataResult<CustomerDetailDto>(null, Messages.CustomerNotExist);
        }


        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult UpdateCustomer(Customer customer)
        {
            var rulesResult = BusinessRules.Run(CheckIfCustomerIdExist(customer.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }


        private IResult CheckIfCustomerIdExist(Guid customerId)
        {
            var result = _customerDal.GetAll(c => c.Id == customerId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CustomerNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserIdExist(Guid userId)
        {
            var result = _customerDal.GetAll(c => c.UserId == userId).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyCustomer);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserIdValid(Guid userId)
        {
            var result = _userService.GetUserById(userId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.UserNotExist);
            }

            return new SuccessResult();
        } 
        
        private IResult CheckIfUserExist(string email)
        {
            var result = _userService.GetByMail(email);
            if (result != null)
            {
                return new ErrorResult(Messages.UserNotExist);
            }

            return new SuccessResult();
        }

        public int GetFindexScore(Guid customerId)
        {
            return _customerDal.GetWithDetails(c=>c.CustomerId==customerId).FindexScore;
        }
    }
}
