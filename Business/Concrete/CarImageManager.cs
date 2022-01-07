using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        [SecuredOperation("carimage.add,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCarImage(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckImageRestriction(carImage.CarId));

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
            _carImageDal.Add(carImage);

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
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carimage.update,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult UpdateCarImage(CarImage carImage, IFormFile file)
        {
          
            var filePath=  _carImageDal.Get(i => i.Id == carImage.Id);

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

        [SecuredOperation("carimage.getcarimagebyid,customer,admin")]
        [CacheAspect]
        public IDataResult<CarImage> GetCarImageById(int carImageId)
        {
           return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == carImageId));
        }

        //[SecuredOperation("carimage.getallcarimagesbycarid,customer,admin")]
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllCarImagesByCarId(int carId)
        {
            var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId));
            if (result.Data.Count==0)
            {
               result.Data.Add(_carImageDal.Get(x=>x.Id ==1));

               return result;
            }

            return result;
        }
        

        // ------ Business Rules ca
        private IResult CheckImageRestriction(int carID)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carID).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CheckImageRestriction);
            }

            return new SuccessResult();
        }


    }
}
