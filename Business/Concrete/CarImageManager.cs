using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Http=Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public async Task<IDataResult<List<CarImage>>> GetAllCarImages()
        {
            var result = await _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(result, Messages.CarImageListed);
        }

        [SecuredOperation("carimage.add,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public async Task<IResult> AddCarImage(CarImage carImage, Http.IFormFile file)
        {
            var result = BusinessRules.Run((Task<IResult>)CheckImageRestrictionAsync(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var uploadResult = FileHelperManager.Upload(file, Paths.CarImages);

            if (!uploadResult.Success)
            {
                return new ErrorResult();
            }
            var path = uploadResult.Data.Remove(0,8);
            carImage.ImagePath = path;

            carImage.Date =DateTime.Now;
            _carImageDal.AddAsync(carImage);

            return new SuccessResult();


        }



        [SecuredOperation("carimage.delete,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult DeleteCarImage(CarImage carImage)
        {

            var deleteResult = FileHelperManager.Delete(carImage.ImagePath);

            if (!deleteResult.Success)
            {
                return new ErrorResult();
            }
            _carImageDal.Remove(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carimage.update,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public async Task<IResult> UpdateCarImage(CarImage carImage, Http.IFormFile file)
        {
          
            var filePath= await _carImageDal.GetAsync(i => i.Id == carImage.Id);

            var updateResult = FileHelperManager.Update(file, filePath.ImagePath ,Paths.CarImages);

            if (!updateResult.Success)
            {
                return new ErrorResult(Messages.FileDeletionException);
            }

            carImage.ImagePath = updateResult.Data;
            carImage.Date=DateTime.Now;

            _carImageDal.Update(carImage);

            return new SuccessResult();

        }

        //[SecuredOperation("carimage.getcarimagebyid,customer,admin")]
        [CacheAspect]
        public async Task<IDataResult<CarImage>> GetCarImageById(Guid carImageId)
        {
            var result = await _carImageDal.GetAsync(i => i.Id == carImageId);
           return new SuccessDataResult<CarImage>();
        }

        //[SecuredOperation("carimage.getallcarimagesbycarid,customer,admin")]
        [CacheAspect]
        public async Task<IDataResult<List<CarImage>>> GetAllCarImagesByCarId(Guid carId)
        {
            var result = new SuccessDataResult<List<CarImage>>(await _carImageDal.GetAll(x => x.CarId == carId));
            if (result.Data.Count==0)
            {
               result.Data.Add(await _carImageDal.GetAsync(x=>x.Id ==Guid.Empty));

               return result;
            }

            return result;
        }


        // ------ Business Rules ca
        private  IResult CheckImageRestrictionAsync(Guid carID)
        {
            var result =  _carImageDal.GetAll(c => c.CarId == carID).Result.Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CheckImageRestriction);
            }

            return new SuccessResult();
        }


    }
}
