using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using Core.Services;
using System.Linq;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {
        IDataResult<IQueryable<Car>> GetAllCars();
        IDataResult<Car> AddCar(CarCreateDto car);
        //IResult DeleteCar(Guid id);
        IDataResult<CarUpdateDto> UpdateCar(CarUpdateDto car);
        IDataResult<Car> GetCarById(Guid carId);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByBrandId(Guid brandId);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByColorId(Guid colorId);
        IDataResult<IQueryable<CarDetailDto>> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        IDataResult<IQueryable<CarDetailDto>> CarTopCarsDetails(int top);
        IDataResult<CarDetailDto> CarDetailsById(Guid carId);
        IDataResult<IEnumerable<CarGridDto>> GetPaged(int page, int pageSize);
    }
}
