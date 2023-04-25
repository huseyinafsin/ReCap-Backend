using Business.Abstract;
using Core.Services;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly IService<GearType> _gearTypeService;

        private readonly IService<Color>  _colorService;

        public SystemController(IService<GearType> gearTypeService, IService<Color> colorService)
        {
            _gearTypeService = gearTypeService;
            _colorService = colorService;
        }

        #region Gear Types

        [HttpGet("gearType")]
        public async Task<IActionResult> GetAllGearTypes()
        {
            var result = await _gearTypeService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("gearType/{id}")]
        public async Task<IActionResult> GetGearType(Guid id)
        {
            var result = await _gearTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("gearType")]
        public async Task<IActionResult> AddGearType(GearType gearType)
        {
            var result = await _gearTypeService.AddAsync(gearType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("gearType")]
        public IActionResult UpdateGearType(GearType gearType)
        {
            var result = _gearTypeService.Update(gearType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("gearType")]
        public async Task<IActionResult> DeleteGearType(Guid id)
        {
            var result = await _gearTypeService.RemoveAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
        #region Gear Types

        [HttpGet("color")]
        public async Task<IActionResult> GetAllColors()
        {
            var result = await _colorService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("color/{id}")]
        public async Task<IActionResult> GetColor(Guid id)
        {
            var result = await _colorService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("color")]
        public async Task<IActionResult> AddGColor(Color color)
        {
            var result = await _colorService.AddAsync(color);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("color")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("color")]
        public async Task<IActionResult> DeleteColor(Guid id)
        {
            var result = await _colorService.RemoveAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion

    }
}
