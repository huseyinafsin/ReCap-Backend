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
        public async Task<IResult> AddCustomer(Customer customer)
        {
            var rulesResult = BusinessRules.Run((Task<IResult>)CheckIfUserIdValidAsync(customer.UserId), CheckIfUserIdExist(customer.UserId));
            if (rulesResult != null)
            {
                return new ErrorResult( rulesResult.Message);
            }

            _customerDal.AddAsync(customer);
            var result =await _customerDal.GetAsync(c => c.UserId == customer.UserId && c.CompanyName == customer.CompanyName);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result, Messages.CustomerAdded);
            }

            return new ErrorResult( Messages.NotAddedCustomer);

        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer")]
        //[ValidationAspect(typeof(CustomerValidator))]
        public async Task<IResult> DeleteCustomer(Customer customer)
        {

            var rulesResult = BusinessRules.Run((Task<IResult>)CheckIfCustomerIdExist(customer.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedCustomer =await _customerDal.GetAsync(c => c.Id == customer.Id);
            _customerDal.Remove(deletedCustomer);
            return new SuccessResult(Messages.CustomerDeleted);
        }


        [CacheAspect(10)]
        [SecuredOperation("admin")]
        public async Task<IDataResult<List<Customer>>> GetAllCustomers()
        {
            var result = await _customerDal.GetAll();

            return new SuccessDataResult<List<Customer>>(result,Messages.CustomerListed);
        }

        [CacheAspect()]
        [SecuredOperation("admin,customer")]
        public async Task<IDataResult<Customer>> GetCustomerById(Guid customerId)
        {
            var result =await _customerDal.GetAsync(c => c.Id == customerId);
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
            var rulesResult = BusinessRules.Run((Task<IResult>)CheckIfCustomerIdExist(customer.Id));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }


        private IResult CheckIfCustomerIdExist(Guid customerId)
        {
            var result = _customerDal.GetAll(c => c.Id == customerId).Result.Any();
            if (!result)
            {
                return new ErrorResult(Messages.CustomerNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserIdExist(Guid userId)
        {
            var result = _customerDal.GetAll(c => c.UserId == userId).Result.Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyCustomer);
            }
            return new SuccessResult();
        }

        private async Task<IResult> CheckIfUserIdValidAsync(Guid userId)
        {
            var result =await _userService.GetUserById(userId);
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
