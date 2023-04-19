using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Http =Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
        IResult AddCarImage(CarImage carImage, Http.IFormFile file);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage, Http.IFormFile file);
        IDataResult<CarImage> GetCarImageById(Guid carImageId);
        IDataResult<List<CarImage>> GetAllCarImagesByCarId(Guid carId);
    }
}
