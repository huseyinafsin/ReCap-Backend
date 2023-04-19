using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [CacheRemoveAspect("IUserService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }


        [CacheRemoveAspect("IUserService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }


        [CacheAspect]
        [SecuredOperation("admin,customer")]
        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }


        //[CacheAspect]
        //[SecuredOperation("admin,customer")]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }


        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<User> GetUserById(Guid userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Id == userId), Messages.UserFetched);
        }


        [CacheRemoveAspect("IUserService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
