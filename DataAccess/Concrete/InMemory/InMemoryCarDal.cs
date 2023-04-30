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
    public class InMemoryCarDal 
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>{

                new Car{ Id=new Guid(), BrandId=new Guid(),   ColorId=new Guid(),  Model="2016",   Description="araçlarımızı kalitelidir"},
                new Car{ Id=new Guid(), BrandId=new Guid(),   ColorId=new Guid(),  Model="2005",  Description="araçlarımızı kalitelidir"},
                new Car{ Id=new Guid(), BrandId=new Guid(),   ColorId=new Guid(),  Model="2016",   Description="araçlarımızı kalitelidir"},
                new Car{ Id=new Guid(), BrandId=new Guid(),   ColorId=new Guid(),  Model="2016",    Description="araçlarımızı kalitelidir"}
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

        public CarDetailDto CarDetailsById(Guid carId)
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

        public Car GetById(Guid id)
        {
            return _cars.Single(x => x.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Single(x => x.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Model = car.Model;
            carToUpdate.Description = car.Description;
        }
    }
}
