using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;   
        }

        [HttpGet("getall")]
        public  IActionResult GetAll()
        {
            var result = _brandService.GetAllBrands().Result;

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid brandId)
        {
            var result =await _brandService.GetBrandById(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Brand brand)
        {
            var result = _brandService.AddBrand(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] Brand brand)
        {
            var result = _brandService.DeleteBrand(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody]Brand brand)
        {
            var result = _brandService.UpdateBrand(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
