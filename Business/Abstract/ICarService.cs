using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System.Linq.Expressions;
using System;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IResult AddCar(Car car);
        IResult DeleteCar(Car car);
        IResult UpdateCar(Car car);
        IDataResult<Car> GetCarById(Guid carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(Guid brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(Guid colorId);
        IDataResult<List<CarDetailDto>> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        IDataResult<List<CarDetailDto>> CarTopCarsDetails(int top);
        IDataResult<CarDetailDto> CarDetailsById(Guid carId);

    }
}
