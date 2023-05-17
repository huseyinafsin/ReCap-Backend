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
using AutoMapper;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;

namespace Business.Concrete
{
    public class CarManager : Service<Car>, ICarService 
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;
        private readonly ICarImageService _carImageService;
        public CarManager(ICarDal carDal, IMapper mapper, ICarImageService carImageService) : base(carDal)
        {
            _carDal = carDal;
            _mapper = mapper;
            _carImageService = carImageService;
        }

        //[CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<Car> AddCar( CarCreateDto car)
        {
           var mapped = _mapper.Map<Car>(car);
           var result = _carDal.Add(mapped);
            return new SuccessDataResult<Car>(Messages.CarAdded);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<IQueryable<CarDetailDto>> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
           
            return new SuccessDataResult<IQueryable<CarDetailDto>>( _carDal.CarDetails(),Messages.CarListed);
            
        }

        public IDataResult<IQueryable<CarDetailDto>> CarTopCarsDetails(int top)
        {
            return new SuccessDataResult<IQueryable<CarDetailDto>>(
                _carDal.CarDetails().OrderBy(x=>x.DailyPrice).Take(top).AsQueryable(), Messages.CarListed);
        }

        public IDataResult<CarDetailDto> CarDetailsById(Guid carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.CarDetailsById(carId), Messages.CarListed);
        }

        //[CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin,customer")]
        //[ValidationAspect(typeof(CarValidator))]
        //public IResult DeleteCar(Guid car)
        //{

        //    _carDal.Remove(car);
        //    return new SuccessResult(Messages.CarDeleted);
        //}

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<IQueryable<Car>> GetAllCars()
        {
          return new SuccessDataResult<IQueryable<Car>>( _carDal.GetAll(),Messages.CarListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<Car> GetCarById(Guid carId)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.Id == carId),Messages.CarFetched);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<IQueryable<CarDetailDto>> GetCarsByBrandId(Guid brandId)
        {
            return new SuccessDataResult<IQueryable<CarDetailDto>>(_carDal.CarDetails(c=>c.BrandId == brandId),Messages.CarListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<IQueryable<CarDetailDto>> GetCarsByColorId(Guid colorId)
        {
            return new SuccessDataResult<IQueryable<CarDetailDto>>(_carDal.CarDetails(c=>c.ColorId == colorId),Messages.CarListed) ;
        }

        //[CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(CarValidator))]
        public IDataResult<CarUpdateDto> UpdateCar(CarUpdateDto carDto)
        {
                
            var car = _mapper.Map<Car>(carDto);
            var updatedCar  = _carDal.Update(car);
            var result = _mapper.Map<CarUpdateDto>(updatedCar);


            return new  SuccessDataResult<CarUpdateDto>(result, Messages.CarUpdated);
        }

        public IDataResult<CarGridModelDto> GetPaged(int page, int pageSize)
        {
            var result = _carDal.GetPaged(page, pageSize);
            return new SuccessDataResult<CarGridModelDto>( result, Messages.CarListed);

        }

    }
}
