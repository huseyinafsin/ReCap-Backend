using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAllCreditCard();
        IDataResult<List<CreditCard>> GetCardsByCustomerId(int customerId);
        IResult AddCreditCard(CreditCard creditCard);
        IResult DeleteCreditCard(CreditCard creditCard);
        IResult UpdateCreditCard(CreditCard creditCard);
        IDataResult<CreditCard> GetCreditCardById(int creditCardId);
        IDataResult<bool> CheckCreditCard(CreditCard creditCard);
    }
}
