using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,ReCapContext>, IRentalDal
    {
       

        List<RentalDetailDto> IRentalDal.RentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join ca in context.Cars
                                on r.CarId equals ca.Id
                             join cu in context.Customers
                                on r.CustomerId equals cu.Id
                             join u in context.Users
                                on cu.UserId equals u.Id
                             join b in context.Brands
                                 on ca.BrandId equals b.Id
                             join p in context.Payments
                                 on r.PaymentId equals p.Id
                             join co in context.Colors
                                 on ca.ColorId equals co.Id


                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = ca.Id,
                                 ModelFullName = $"{b.Name} {ca.CarName}",
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 CustomerId = cu.Id,
                                 CustomerFullName = $"{u.FirstName} {u.LastName}",
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = ca.DaiyPrice,
                                 RentDate = r.RentDate,
                                 PaymentId = r.PaymentId,
                                 PaymentDate = p.PaymentDate,
                                 DeliveryStatus = r.DeliveryStatus
                             };
                return result.ToList();
            }
        }


        public IResult AddRentalWithDetails(RentalAddDto rental)
        {
            using (ReCapContext context = new ReCapContext())
            {
               var creditCard = context.CreditCards.FirstOrDefault(c => c.CardNumber == rental.CardNumber.Trim() &&
                                                        c.CardHolderFullName == rental.CardHolderFullName.Trim() &&
                                                        c.ExpireYear == rental.ExpiredYear.Trim() &&
                                                        c.ExpireMonth == rental.ExpiredMonth.Trim() &&
                                                        c.Cvc == rental.Cvc.Trim()
                );

               if (creditCard == null)
               {
                   return new ErrorResult("Check your credit card");
               }

               creditCard.Balance = creditCard.Balance -rental.Amount;
               context.CreditCards.Update(creditCard);
               context.SaveChanges();

               var car = context.Cars.FirstOrDefault(c => c.Id == rental.CarId);

               if (car == null)
               {
                   return new ErrorResult("I don't know what car trying to add");
               }

               var customer = context.Customers.FirstOrDefault(c => c.Id == rental.CustomerId);

               if (customer == null)
               {
                   return new ErrorResult("I don't you who you are. Try login again");
               }

               var payment = new Payment
               {
                    CreditCardId = creditCard.Id,
                    Amount = rental.Amount,
                    CustomerId = customer.Id,
                    PaymentDate = DateTime.Now
               };

               context.Payments.Add(payment);
               context.SaveChanges();

               var newRental = new Rental
               {
                   RentDate = rental.RentDate,
                   ReturnDate = rental.ReturnDate,
                   CustomerId = customer.Id,
                   CarId = car.Id,
                   PaymentId = payment.Id,
                   DeliveryStatus = true
                   
               };

               context.Rentals.Add(newRental);
               context.SaveChanges();

               return new SuccessResult("Car successful rented");

            }
        }

    }
}

