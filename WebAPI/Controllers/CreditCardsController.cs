﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = _creditCardService.GetAllCreditCard();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getcardsbycustomerId")]
        public async Task<IActionResult> GetCardsByCustomerId(Guid customerId)
        {
            var result = _creditCardService.GetCardsByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(Guid creditCardId)
        {
            var result =  _creditCardService.GetCreditCardByIdAsync(creditCardId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.AddCreditCard(creditCard);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardService.DeleteCreditCard(creditCard);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardService.UpdateCreditCard(creditCard);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("checkcreditcard")]
        public IActionResult CheckCreditCard(CreditCard creditCard)
        {
            var result = _creditCardService.CheckCreditCard(creditCard);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        } 
        
        [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(Guid customerId, string cardNumber)
        {
            var result = _creditCardService.SaveCreditCard(customerId, cardNumber);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
