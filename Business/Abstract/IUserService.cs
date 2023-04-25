using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;
using Core.Entities.Concrete;
using System;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAllUsers();
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
        Task<IDataResult<User>> GetUserById(Guid userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        Task<User> GetByMail(string email);
    }
}
