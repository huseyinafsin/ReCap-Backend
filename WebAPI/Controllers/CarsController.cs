using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;   
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbybrand")]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetAllByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("cardetails")]
        public IActionResult Details()
        {
            var result = _carService.CarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("cardetailsbyid")]
        public IActionResult CarDetailsById(int carId)
        {
            var result = _carService.CarDetailsById(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);  
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int cardId)
        {
            var result = _carService.GetCarById(cardId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Car car)
        {
            var result = _carService.AddCar(car);

            if (result.Success)
            {
                return Ok(car);
            }   

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Car car)
        {
            var result = _carService.DeleteCar(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] Car car)
        {
            var result = _carService.UpdateCar(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(car);
        }
    }
}
