﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public  class EfUserDal :Repository<User>, IUserDal
    {

        public EfUserDal(DbContext context) : base(context)
        {
        }

        public IQueryable<OperationClaim> GetClaims(User user)
        {
            //using (var context = new ReCapContext ())
            //{
            //    var result = from operationClaim in context.OperationClaims
            //        join userOperationClaim in context.UserOperationClaims
            //            on operationClaim.Id equals userOperationClaim.OperationClaimId
            //        where userOperationClaim.UserId == user.Id
            //        select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            //    return result.AsQueryable();

            //}
            throw new NotImplementedException();

        }
    }
}
