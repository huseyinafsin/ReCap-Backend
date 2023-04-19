﻿using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;
using Core.Entities.Concrete;
using System;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUsers();
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
        IDataResult<User> GetUserById(Guid userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);
    }
}
