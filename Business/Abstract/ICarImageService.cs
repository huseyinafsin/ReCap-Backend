using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Http =Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        Task<IDataResult<List<CarImage>>> GetAllCarImages();
        Task<IResult> AddCarImage(CarImage carImage, Http.IFormFile file);
        IResult DeleteCarImage(CarImage carImage);
        Task<IResult> UpdateCarImage(CarImage carImage, Http.IFormFile file);
        Task<IDataResult<CarImage>> GetCarImageById(Guid carImageId);
        Task<IDataResult<List<CarImage>>> GetAllCarImagesByCarId(Guid carId);
    }
}
