using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
       Task<IDataResult<List<Brand>>> GetAllBrands();
       IResult AddBrand(Brand brand);
       IResult DeleteBrand(Brand brand);
       IResult UpdateBrand(Brand brand);
       Task<IDataResult<Brand>> GetBrandById(Guid brandId);
    }
}
