using System;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RentalsController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAllRentals();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("details")]
        public IActionResult GetRentalDetail()
        {
            var result = _rentalService.GetRentalDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid rentalId)
        {
            var result = _rentalService.GetRentalById(rentalId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.AddRental(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        } 
        
        [HttpPost("rent")]
        public IActionResult Rent([FromBody] RentalAddDto rental)
        {
            var result = _rentalService.AddRentalWithDetails(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.DeleteRental(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.UpdateRental(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("isrentable")]
        public IActionResult CheckCanRent(Guid carId, DateTime rentDate, DateTime returnDate)
        {
            var result = _rentalService.IsRentable(carId,  rentDate,  returnDate);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
     


    }
}


