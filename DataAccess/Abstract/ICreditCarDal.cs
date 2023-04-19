using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Abstract
{ 
    public interface ICreditCardDal : IEntityRepository<CreditCard>
    {
        bool CheckCreditCard(CreditCard creditCard);
        CreditCard GetCreditCardByCardNumber(string cardNumber);
        bool SaveCreditCard(Guid customerId,string cardNumber);

    }
}
