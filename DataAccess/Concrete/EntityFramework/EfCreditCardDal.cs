using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditCardDal : Repository<CreditCard>, ICreditCardDal
    {
        public EfCreditCardDal(DbContext context) : base(context)
        {
        }

        public bool CheckCreditCard(CreditCard creditCard)
        {
            //using (ReCapContext context =new ReCapContext())
            //{
            //    var result = context.CreditCards.FirstOrDefault(c => c.CardNumber == creditCard.CardNumber);
            //    if (result!=null 
            //        && result.CardHolderFullName ==creditCard.CardHolderFullName 
            //        && result.ExpireYear == creditCard.ExpireYear
            //        && result.ExpireMonth == creditCard.ExpireMonth
            //        && result.Cvc == creditCard.Cvc)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            throw new NotImplementedException();

        }

        public CreditCard GetCreditCardByCardNumber(string cardNumber)
        {
            //using(ReCapContext context = new ReCapContext())
            //{
            //    var result = context.CreditCards.FirstOrDefault(c=>c.CardNumber==cardNumber);
            //    return result;
            //}
            throw new NotImplementedException();

        }

        public bool SaveCreditCard(Guid customerId, string cardNumber)
        {
            //using (ReCapContext context = new ReCapContext())
            //{
            //    var creditCard = GetCreditCardByCardNumber(cardNumber);
            //    creditCard.CustomerId = customerId;
            //    context.Update(creditCard);
            //    context.SaveChanges();
            //}

            return true;
        }
    }
}
