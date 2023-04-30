using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IPaymentService : IService<Payment>
{
    Task<IDataResult<IQueryable<Payment>>> GetAllPayment();
    IResult AddPayment(Payment payment);
    IResult DeletePayment(Payment payment);
    IResult UpdatePayment(Payment payment);
    Task<IDataResult<Payment>> GetPaymentById(Guid paymentId);
}