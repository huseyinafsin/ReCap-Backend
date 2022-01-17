using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>{

                new Car{ Id=1, BrandId=1,   ColorId=2,  ModelYear=2016, DaiyPrice=500,    Description="araçlarımızı kalitelidir"},
                new Car{ Id=2, BrandId=2,   ColorId=1,  ModelYear=2005, DaiyPrice=900,    Description="araçlarımızı kalitelidir"},
                new Car{ Id=3, BrandId=3,   ColorId=2,  ModelYear=2022, DaiyPrice=65,    Description="araçlarımızı kalitelidir"},
                new Car{ Id=4, BrandId=3,   ColorId=3,  ModelYear=2015, DaiyPrice=956,    Description="araçlarımızı kalitelidir"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

     

        public List<CarDetailDto> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto CarDetailsById(int carId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.Single(x => x.Id == car.Id);

            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.Single(x => x.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Single(x => x.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DaiyPrice = car.DaiyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
