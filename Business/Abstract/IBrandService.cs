using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Business.Abstract
{
    public interface IBrandService
    {
       IDataResult<IQueryable<Brand>> GetAllBrands();
       IResult AddBrand(Brand brand);
       IResult DeleteBrand(Brand brand);
       IResult UpdateBrand(Brand brand);
       IDataResult<Brand> GetBrandById(Guid brandId);
    }
}
