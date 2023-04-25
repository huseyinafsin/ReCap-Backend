using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            var result =await _carService.GetAllCars();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbybrand")]
        public IActionResult GetAllByBrandId(Guid brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetAllByColorId(Guid colorId)
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
        
        [HttpGet("gettopcheapcars")]
        public IActionResult GetTopCheapCars(int top)
        {
            var result = _carService.CarTopCarsDetails(top);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("cardetailsbyid")]
        public IActionResult CarDetailsById(Guid carId)
        {
            var result = _carService.CarDetailsById(carId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);  
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid cardId)
        {
            var result =await _carService.GetCarById(cardId);

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
