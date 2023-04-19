using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin,customer")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddBrand(Brand brand)
        {

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }


        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult DeleteBrand(Brand brand)
        {

            _brandDal.Delete(brand);

            return new SuccessResult(Messages.BrandListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<List<Brand>> GetAllBrands()
        {
           
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed) ;
        }

        [CacheAspect]
        //[SecuredOperation("admin,customer")]
        public IDataResult<Brand> GetBrandById(Guid brandId)
        {
           return new SuccessDataResult<Brand>( _brandDal.Get(b => b.Id == brandId),Messages.BrandFetched);
        }

        [ValidationAspect(typeof(BrandValidator))]

        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin,customer")]
        public IResult UpdateBrand(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
