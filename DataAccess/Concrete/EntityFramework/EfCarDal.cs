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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
     

    
        public List<CarDetailDto> CarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DaiyPrice,
                                 Description = ca.Description,
                                 MinFindexScore = ca.MinFindexScore,
                                 Images = context.CarImages.Where(x => x.CarId == ca.Id).ToList()

                             };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
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
                        ModelYear = ca.ModelYear,
                        DailyPrice = ca.DaiyPrice,
                        Description = ca.Description,
                        MinFindexScore = ca.MinFindexScore,
                        Images = context.CarImages.Where(x => x.CarId == ca.Id).ToList()

                    };


                return result.FirstOrDefault(x=>x.Id==carId);
            }
        }
    }
}
