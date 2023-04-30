using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
            using (ReCapContext context = new ReCapContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                                 on ca.BrandId equals b.Id
                             join co in context.Colors
                                 on ca.ColorId equals co.Id
                             select new CarDetailDto()
                             {
                                 Id = ca.Id,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 Model = ca.Model,
                                 //DailyPrice = ca.DaiyPrice,
                                 Description = ca.Description,
                                 MinFindexScore = ca.MinFindexScore,
                                 Images = context.CarImages.Where(x => x.CarId == ca.Id).ToList()

                             };


                return filter == null ? result.AsQueryable().AsNoTracking() : result.Where(filter).AsQueryable().AsNoTracking();
            }
        }

        public CarDetailDto CarDetailsById(Guid carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                                 on ca.BrandId equals b.Id
                             join co in context.Colors
                                 on ca.ColorId equals co.Id
                             select new CarDetailDto()
                             {
                                 Id = ca.Id,
                                 CarName = ca.CarName,
                                 BrandName = b.Name,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ColorName = co.Name,
                                 Model = ca.Model,
                                 //DailyPrice = ca.DaiyPrice,
                                 Description = ca.Description,
                                 MinFindexScore = ca.MinFindexScore,
                                 Images = context.CarImages.Where(x => x.CarId == ca.Id).ToList()

                             };


                return result.FirstOrDefault(x => x.Id == carId);
            }
        }

        public IEnumerable<CarGridDto> GetPaged(int page, int pageSize)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Cars
                .Include(x => x.Brand)
                .Include(x => x.Color)
                .Include(x => x.CarType)
                .Include(x => x.GearType)
                .Include(x => x.FuelType)
                .OrderBy(x => x.InsertedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
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
}
