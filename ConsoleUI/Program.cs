using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;
using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            // addUsersTest();
            //addCarTest(carManager);
            //listCarTest(carManager);
            // modifyCarTest(carManager);
            // deleteCarTest(carManager);

            // RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //
            // var result = rentalManager.AddRental(new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now });
            // if (result.Success)
            //     Console.WriteLine(result.Message);
            // else
            //     Console.WriteLine(result.Message);

            // listCars(carManager);

            //UserManager _userManager = new UserManager(new EfUserDal());
            //Console.WriteLine(_userManager.GetByMail("admin@mail.com").FirstName);

            //Console.WriteLine("Merhaba");
            //var images = context.CarImages.ToList();
            //foreach (var image in images)
            //{
            //    Console.WriteLine(image.ImagePath + "\n");

            //}

        }
    }
}
