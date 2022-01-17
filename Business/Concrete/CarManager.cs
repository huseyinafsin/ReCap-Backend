using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar( Car car)
        {
          
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<CarDetailDto>> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
           
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.CarDetails(),Messages.CarListed);
            
        }

        public IDataResult<List<CarDetailDto>> CarTopCarsDetails(int top)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                _carDal.CarDetails().OrderBy(x=>x.DailyPrice).Take(top).ToList(), Messages.CarListed);
        }

        public IDataResult<CarDetailDto> CarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.CarDetailsById(carId), Messages.CarListed);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult DeleteCar(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<Car>> GetAllCars()
        {
          return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<Car> GetCarById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId),Messages.CarAdded);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails(c=>c.BrandId == brandId),Messages.CarListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails(c=>c.ColorId == colorId),Messages.CarListed) ;
        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
                
            _carDal.Update(car);
            return new  SuccessResult(Messages.CarUpdated);
        }

      
    }
}
