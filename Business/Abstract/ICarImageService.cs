﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Http =Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllCarImages();
        IResult AddCarImage(Guid carId, Http.IFormFile file);
        IResult DeleteCarImage(Guid id);
        IResult UpdateCarImage(CarImage carImage, Http.IFormFile file);
        IDataResult<CarImage> GetCarImageById(Guid carImageId);
        IDataResult<IEnumerable<CarImage>> GetAllCarImagesByCarId(Guid carId);
    }
}
