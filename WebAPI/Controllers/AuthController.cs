using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin =await _authService.LoginAsync(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }      
        
        [HttpPost("customerregister")]
        public async Task<ActionResult> CustomerRegisterAsync(CustomerForRegister customerForRegister)
        {
            var userExists = _authService.UserExists(customerForRegister.Email);
            if (userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult =await _authService.CustomerRegister(customerForRegister, customerForRegister.Password);
            var user =await _userService.GetUserById(registerResult.Data.UserId);
            var result = _authService.CreateAccessToken(user.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message); 
        }
    }
}
