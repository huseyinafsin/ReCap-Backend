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
        private readonly IService<Brand> _brandService;
        private readonly IService<FuelType> _fuelTypeService;
        private readonly IService<InsuranceType> _insuranceTypeService;
        private readonly IService<CarType> _carTypeService;




        public SystemController(IService<GearType> gearTypeService,
            IService<Color> colorService,
            IService<FuelType> fuelTypeService,
            IService<InsuranceType> insuranceTypeService,
            IService<CarType> carTypeService,
        IService<Brand> brandService)
        {
            _gearTypeService = gearTypeService;
            _colorService = colorService;
            _brandService = brandService;
            _fuelTypeService = fuelTypeService;
            _insuranceTypeService = insuranceTypeService;
            _carTypeService = carTypeService;

        }

        #region Gear Types

        [HttpGet("gearType")]
        public async Task<IActionResult> GetAllGearTypes()
        {
            var result =  _gearTypeService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("gearType/{id}")]
        public async Task<IActionResult> GetGearType(Guid id)
        {
            var result =  _gearTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("gearType")]
        public async Task<IActionResult> AddGearType(GearType gearType)
        {
            var result =  _gearTypeService.Add(gearType);

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


        [HttpDelete("gearType/{id}")]
        public async Task<IActionResult> DeleteGearType(Guid id)
        {
            var result =  _gearTypeService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
        #region Fuel Types

        [HttpGet("fuelType")]
        public async Task<IActionResult> GetAllFuelTypes()
        {
            var result =  _fuelTypeService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("fuelType/{id}")]
        public async Task<IActionResult> GetFuelType(Guid id)
        {
            var result =  _fuelTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("fuelType")]
        public async Task<IActionResult> AddFuelType(FuelType fuelType)
        {
            var result =  _fuelTypeService.Add(fuelType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("fuelType")]
        public IActionResult UpdateFuelType(FuelType fuelType)
        {
            var result = _fuelTypeService.Update(fuelType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("fuelType/{id}")]
        public async Task<IActionResult> DeleteFuelType(Guid id)
        {
            var result =  _fuelTypeService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
        #region Insurance Types

        [HttpGet("insuranceType")]
        public async Task<IActionResult> GetAllInsuranceTypes()
        {
            var result =  _insuranceTypeService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("insuranceType/{id}")]
        public async Task<IActionResult> GetInsuranceType(Guid id)
        {
            var result =  _insuranceTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("insuranceType")]
        public async Task<IActionResult> AddInsuranceType(InsuranceType insuranceType)
        {
            var result =  _insuranceTypeService.Add(insuranceType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("insuranceType")]
        public IActionResult UpdateInsuranceType(InsuranceType insuranceType)
        {
            var result = _insuranceTypeService.Update(insuranceType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("insuranceType/{id}")]
        public async Task<IActionResult> DeleteInsuranceType(Guid id)
        {
            var result =  _insuranceTypeService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
        #region Car Types

        [HttpGet("carType")]
        public async Task<IActionResult> GetAllCarTypes()
        {
            var result =   _carTypeService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("carType/{id}")]
        public async Task<IActionResult> GetCarType(Guid id)
        {
            var result =  _carTypeService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("carType")]
        public IActionResult AddFuelType(CarType carType)
        {
            var result =  _carTypeService.Add(carType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("carType")]
        public IActionResult UpdateCarType(CarType carType)
        {
            var result = _carTypeService.Update(carType);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("carType/{id}")]
        public async Task<IActionResult> DeleteCarType(Guid id)
        {
            var result =  _carTypeService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion

        #region Color

        [HttpGet("color")]
        public IActionResult GetAllColors()
        {
            var result =  _colorService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("color/{id}")]
        public IActionResult GetColor(Guid id)
        {
            var result =  _colorService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("color")]
        public IActionResult AddGColor(Color color)
        {
            var result =  _colorService.Add(color);

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


        [HttpDelete("color/{id}")]
        public IActionResult DeleteColor(Guid id)
        {
            var result =  _colorService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
        #region Brand

        [HttpGet("brand")]
        public  IActionResult GetAllBrands()
        {
            var result =  _brandService.GetAllAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("brand/{id}")]
        public IActionResult GetBrand(Guid id)
        {
            var result =  _brandService.GetByIdAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("brand")]
        public  IActionResult AddBrand(Brand brand)
        {
            var result =  _brandService.Add(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPut("brand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.Update(brand);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpDelete("brand/{id}")]
        public IActionResult DeleteBrand(Guid id)
        {
            var result =  _brandService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion

    }
}
