using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using Business.Abstract;
using Core.Entities.Concrete;

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

           Console.WriteLine("Merhaba");

        }

        private static void listCars(CarManager carManager)
        {
            foreach (var car in carManager.CarDetails().Data)
            {
                Console.WriteLine("Car Name:" + car.CarName + "\n" +
                                  "Color Name:" + car.ColorName + "\n" +
                                  "Brand Name:" + car.BrandName + "\n" +
                                  "Daily Price:" + car.DailyPrice
                                  );

            }
        }

        private static void addUsersTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            //userManager.AddUser(new User { FirstName = "Hüseyin", LastName = "AFŞİN", Email = "huseyinafsin@gmail.com", Password = "123" });

            //userManager.AddUser(new User { FirstName = "Mehmet", LastName = "Komurcuoglu", Email = "mkomurcu@gmail.com", Password = "123" });

            //userManager.AddUser(new User { FirstName = "Zeyneddin", LastName = "Say", Email = "zeyneddin@gmail.com", Password = "123" });
        }

        private static void deleteCarTest(CarManager carManager)
        {
            Car car = carManager.GetCarById(1).Data;
            carManager.DeleteCar(car);
        }

        private static void modifyCarTest(CarManager carManager)
        {
            Car car = carManager.GetCarById(1).Data;
            car.ModelYear = 1999;
            carManager.UpdateCar(car);
        }

        private static void addCarTest(CarManager carManager)
        {
            Car car1 = new Car();
            car1.DaiyPrice = 25;
            car1.BrandId = 1;
            car1.ColorId = 1;
            car1.Description = "pahakı arac";
            car1.ModelYear = 2020;

            Car car2 = new Car();
            car2.DaiyPrice = 20;
            car2.BrandId = 2;
            car2.ColorId = 3;
            car2.Description = "Ucuz arac";
            car2.ModelYear = 2000;
            carManager.AddCar(car1);
            carManager.AddCar(car2);
        }

        private static void listCarTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAllCars().Data)
            {
                Console.WriteLine("Car Id:" + car.Id + "\n Car Description:" + car.Description + "\n");
            }
        }
    }
}
