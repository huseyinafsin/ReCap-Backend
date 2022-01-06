using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
        IResult AddCarImage(CarImage carImage, IFormFile file);
        IResult DeleteCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage,IFormFile file);
        IDataResult<CarImage> GetCarImageById(int carImageId);
        IDataResult<List<CarImage>> GetAllCarImagesByCarId(int carId);
    }
}
