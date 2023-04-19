using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class PaymentManager : IPaymentService
{
    private IPaymentDal _paymentDal;

    public PaymentManager(IPaymentDal paymentDal)
    {
        _paymentDal = paymentDal;
    }

    public IDataResult<List<Payment>> GetAllPayment()
    {
        return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), " Payments listed successful");
    }

    public IResult AddPayment(Payment payment)
    {
        _paymentDal.Add(payment);
        return new SuccessResult("Payment added successful");
    }

    public IResult DeletePayment(Payment payment)
    {
        _paymentDal.Delete(payment);
        return new SuccessResult("Payment deleted successful");
    }

    public IResult UpdatePayment(Payment payment)
    {
        _paymentDal.Update(payment);
        return new SuccessResult("Payment updated successful");
    }

    public IDataResult<Payment> GetPaymentById(Guid paymentId)
    {
        return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == paymentId), "Payment fetched successful");
    }
}