using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IRepository<Car>
    {
        //List<CarDetailDto> CarDetails(CarDetailFilter filter);
        IQueryable<CarDetailDto> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto CarDetailsById(Guid carId);
        CarGridModelDto GetPaged( int page,  int pageSize);
    }
}
