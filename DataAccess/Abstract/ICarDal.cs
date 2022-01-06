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
    public interface ICarDal : IEntityRepository<Car>
    {  
        //List<CarDetailDto> CarDetails(CarDetailFilter filter);
        List<CarDetailDto> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto CarDetailsById(int carId);
    }
}
