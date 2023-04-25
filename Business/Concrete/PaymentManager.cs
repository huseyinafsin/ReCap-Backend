using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class PaymentManager : Service<Payment>, IPaymentService
{
    private IPaymentDal _paymentDal;

    public PaymentManager(IPaymentDal paymentDal) :base(paymentDal)
    {
        _paymentDal = paymentDal;
    }

    public async Task<IDataResult<List<Payment>>> GetAllPayment()
    {
        var result = await _paymentDal.GetAll();
        return new SuccessDataResult<List<Payment>>(result, " Payments listed successful");
    }

    public IResult AddPayment(Payment payment)
    {
        _paymentDal.AddAsync(payment);
        return new SuccessResult("Payment added successful");
    }


    public IResult DeletePayment(Payment payment)
    {
        _paymentDal.Remove(payment);
        return new SuccessResult("Payment deleted successful");
    }

    public IResult UpdatePayment(Payment payment)
    {
        _paymentDal.Update(payment);
        return new SuccessResult("Payment updated successful");
    }

    public async Task<IDataResult<Payment>> GetPaymentById(Guid paymentId)
    {
        var result = await _paymentDal.GetAsync(p => p.Id == paymentId);
        return new SuccessDataResult<Payment>(result, "Payment fetched successful");
    }
}