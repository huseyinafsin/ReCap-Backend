using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;
using Core.Entities.Concrete;
using System;
using Entities.Concrete;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IQueryable<User>> GetAllUsers();
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
        IDataResult<User> GetUserById(Guid userId);
        IDataResult<IQueryable<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);
    }
}
