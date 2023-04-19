using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IPaymentService
{
    IDataResult<List<Payment>> GetAllPayment();
    IResult AddPayment(Payment payment);
    IResult DeletePayment(Payment payment);
    IResult UpdatePayment(Payment payment);
    IDataResult<Payment> GetPaymentById(Guid paymentId);
}