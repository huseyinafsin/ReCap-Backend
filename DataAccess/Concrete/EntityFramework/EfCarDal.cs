using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : Repository<Car>, ICarDal
    {
        
        public EfCarDal(DbContext context) : base(context)
        {
        }

        public IQueryable<CarDetailDto> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            var result = _dbSet
                  .Include(x => x.Brand)
                  .Include(x => x.Color)
                  .Include(x => x.CarImages)
                  .Select(x =>
                      new CarDetailDto
                      {
                          Id = x.Id,
                          CarName = x.CarName,
                          BrandName = x.Brand.Name,
                          BrandId = x.Brand.Id,
                          ColorId = x.Color.Id,
                          ColorName = x.Color.Name,
                          Model = x.Model,
                          Description = x.Description,
                          MinFindexScore = x.MinFindexScore,
                          Images = x.CarImages

                      }
                  );
            return filter==null? result.AsQueryable().AsNoTracking() : result.Where(filter).AsQueryable().AsNoTracking();
        }

        public CarDetailDto CarDetailsById(Guid carId)
        {

            return _dbSet
            .Include(x => x.Brand)
            .Include(x => x.Color)
            .Include(x => x.CarImages)
            .Select(x => 
                new CarDetailDto
                {
                    Id = x.Id,
                    CarName = x.CarName,
                    BrandName = x.Brand.Name,
                    BrandId = x.Brand.Id,
                    ColorId = x.Color.Id,
                    ColorName = x.Color.Name,
                    Model = x.Model,
                    Description = x.Description,
                    MinFindexScore = x.MinFindexScore,
                    Images = x.CarImages

                }
            ).FirstOrDefault(x => x.Id == carId);

        }

        public IEnumerable<CarGridDto> GetPaged(int page, int pageSize)
        {

                return _dbSet
                .Include(x => x.Brand)
                .Include(x => x.Color)
                .Include(x => x.CarType)
                .Include(x => x.GearType)
                .Include(x => x.FuelType)
                .OrderBy(x => x.InsertedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsQueryable()
                .AsNoTracking()
                .Select(x => new CarGridDto
                {
                    Id = x.Id,
                    CarName = x.CarName,
                    Model = x.Model,
                    Brand = x.Brand.Name,
                    Color = x.Color.Name,
                    CarType = x.CarType.Name,
                    Fuel = x.FuelType.Name,
                    Gear = x.GearType.Name,
                    MinFindexScore = x.MinFindexScore,
                });

        }
    }
}
