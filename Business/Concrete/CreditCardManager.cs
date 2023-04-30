using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager :ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<IQueryable<CreditCard>> GetAllCreditCard()
        {
            var result =  _creditCardDal.GetAll();
            return new SuccessDataResult<IQueryable<CreditCard>>(result,"Credit Cards Listed");
        }

        public IResult AddCreditCard(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new  SuccessResult("Credit card added successful");
        }

        public IResult DeleteCreditCard(CreditCard creditCard)
        {
            _creditCardDal.Remove(creditCard);
            return new SuccessResult("Credit card deleted successful");
        }

        public IResult UpdateCreditCard(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult("Credit card updated successful");
        }

        public IDataResult<CreditCard> GetCreditCardByIdAsync(Guid creditCardId) { 
        
            var result =  _creditCardDal.Get(c => c.Id == creditCardId);
            return new SuccessDataResult<CreditCard>(result, "Credit card fetched successful");
        }

        public IDataResult<bool> CheckCreditCard(CreditCard creditCard)
        {
            return new SuccessDataResult<bool>(_creditCardDal.CheckCreditCard(creditCard), "Credit card fetched successful");
        }

        public IDataResult<IQueryable<CreditCard>> GetCardsByCustomerId(Guid customerId)
        {
            var result =  _creditCardDal.GetAll(c => c.CustomerId == customerId);
            return new SuccessDataResult<IQueryable<CreditCard>>(result, "Credit Cards Listed");
        }

        public IDataResult<bool> SaveCreditCard(Guid customerId, string cardNumber)
        {
            return new SuccessDataResult<bool>(_creditCardDal.SaveCreditCard(customerId, cardNumber), Messages.CreditCardSaved);
        }


    }
}
