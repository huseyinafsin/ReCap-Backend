using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfPaymentDal : Repository<Payment>, IPaymentDal
{
    public EfPaymentDal(DbContext context) : base(context)
    {
    }
}