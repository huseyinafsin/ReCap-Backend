using Entities.Concrete;
using System.Collections.Generic;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAllBrands();
        IResult AddBrand(Brand brand);
        IResult DeleteBrand(Brand brand);
        IResult UpdateBrand(Brand brand);
        IDataResult<Brand> GetBrandById(int brandId);
    }
}
