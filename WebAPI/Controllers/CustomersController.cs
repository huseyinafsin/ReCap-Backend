using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails()
        {
            var result = _customerService.GetAllWithDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Guid customerId)
        {
            var result = _customerService.GetCustomerById(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }     
        
        [HttpGet("getfindexscore")]
        public IActionResult GetFindex(Guid customerId)
        {
            var result = _customerService.GetFindexScore(customerId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        } 
        
        [HttpGet("getdetailsbymail")]
        public IActionResult GetDetailByMail(string email)
        {
            var result = _customerService.GetDetailsByMail(email);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        } 
        
        [HttpGet("getwithdetails")]
        public IActionResult GetWithDetails(Guid customerId)
        {
            var result = _customerService.GetCustomerById(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {   
            var result = _customerService.AddCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.DeleteCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.UpdateCustomer(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
