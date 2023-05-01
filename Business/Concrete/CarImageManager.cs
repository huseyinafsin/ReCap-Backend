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
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<IEnumerable<CarImage>> GetAllCarImages()
        {
            var result =  _carImageDal.GetAll();

            return new SuccessDataResult<IEnumerable<CarImage>>(result, Messages.CarImageListed);
        }

        //[SecuredOperation("carimage.add,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCarImage(Guid carId, Http.IFormFile file)
        {   
            //var result = BusinessRules.Run((Task<IResult>)CheckImageRestrictionAsync(carId));

            //if (result != null)
            //{
            //    return result;
            //}

            var uploadResult = FileHelperManager.Upload(file, Paths.CarImages);

            if (!uploadResult.Success)
            {
                return new ErrorResult();
            }
            var path = uploadResult.Data.Remove(0,8);

            var image =new CarImage()
            {
                CarId= carId,
                ImagePath= path,
                Date= DateTime.Now, 
                InsertedAt= DateTime.Now,
                InsertedUserId= Guid.Empty,
            };

            _carImageDal.Add(image);

            return new SuccessResult();


        }



        //[SecuredOperation("carimage.delete,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult DeleteCarImage(Guid id)
        {
            var image = _carImageDal.Get(x => x.Id == id);
            var deleteResult = FileHelperManager.Delete(image.ImagePath);

            if (!deleteResult.Success)
            {
                return new ErrorResult();
            }
            _carImageDal.Remove(image);
            return new SuccessResult("Image has been deleted");
        }

        [SecuredOperation("carimage.update,customer,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public  IResult UpdateCarImage(CarImage carImage, Http.IFormFile file)
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

        //[SecuredOperation("carimage.getcarimagebyid,customer,admin")]
        [CacheAspect]
        public  IDataResult<CarImage> GetCarImageById(Guid carImageId)
        {
            var result =  _carImageDal.Get(i => i.Id == carImageId);
           return new SuccessDataResult<CarImage>();
        }

        //[SecuredOperation("carimage.getallcarimagesbycarid,customer,admin")]
        [CacheAspect]
        public IDataResult<IEnumerable<CarImage>> GetAllCarImagesByCarId(Guid carId)
        {
            var result = new SuccessDataResult<IEnumerable<CarImage>>( _carImageDal.GetAll(x => x.CarId == carId));
            if (result.Data.Count()==0)
            {
                var defaultImg = _carImageDal.Get(x => x.Id == Guid.Empty);
               result.Data.Append(defaultImg);

               return result;
            }

            return result;
        }


        // ------ Business Rules ca
        private  IResult CheckImageRestrictionAsync(Guid carID)
        {
            var result =  _carImageDal.GetAll(c => c.CarId == carID).Count();

            if (result >= 5)
            {
                return new ErrorResult(Messages.CheckImageRestriction);
            }

            return new SuccessResult();
        }

        IDataResult<List<CarImage>> ICarImageService.GetAllCarImages()
        {
            throw new NotImplementedException();
        }

    }
}
