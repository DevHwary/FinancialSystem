using FinSystem.Application.DTOs;
using FinSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            var result = await _userService.RegisterUserAsync(registrationDto);
            if (result)
                return Ok("User registered successfully");
            return BadRequest("Failed to register user");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _userService.AuthenticateUserAsync(loginDto);
            if (!string.IsNullOrEmpty(token))
                return Ok(new { Token = token });
            return Unauthorized("Invalid credentials");
        }
    }
}
