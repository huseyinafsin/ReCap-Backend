using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _carImageService.GetAllCarImages();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getallcarimagesbyid")]
        public async Task<IActionResult> GetAllCarImagesByCarId(Guid carId)
        {
            var result =await _carImageService.GetAllCarImagesByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid imageId)
        {
            var result =await _carImageService.GetCarImageById(imageId);

            if (result.Success)
            {             
                return Ok(result);

            }

            return BadRequest(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(  [FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result =await _carImageService.AddCarImage(carImage, file);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody]CarImage carImage )
        {
            var result = _carImageService.DeleteCarImage(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(CarImage carImage,[FromForm] IFormFile file)
        {
            var result =await _carImageService.UpdateCarImage(carImage,file);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
