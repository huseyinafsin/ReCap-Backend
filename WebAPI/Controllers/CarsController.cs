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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = _carService.GetAllCars();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("[action]")]
        public IActionResult GetPaged(int page, int pageSize)
        {
            var result =  _carService.GetPaged( page, pageSize);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("[action]/{id}")]
        public IActionResult GetAllByBrandId(Guid id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAllByColorId(Guid id)
        {
            var result = _carService.GetCarsByColorId(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult Details()
        {
            var result = _carService.CarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }  
        
        [HttpGet("[action]/{top}")]
        public IActionResult GetTopCheapCars(int top)
        {
            var result = _carService.CarTopCarsDetails(top);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("details/{id}")]
        public IActionResult CarDetailsById(Guid id)
        {
            var result = _carService.CarDetailsById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);  
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = _carService.GetCarById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarCreateDto car)
        {
            var result = _carService.AddCar(car);

             if (result.Success)
            {
                return Ok(result);
            }   

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result =  _carService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CarUpdateDto car)
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
