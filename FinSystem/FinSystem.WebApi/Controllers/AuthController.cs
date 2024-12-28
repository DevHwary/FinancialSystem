using FinSystem.Application.DTOs;
using FinSystem.Application.Enums;
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

            switch (result)
            {
                case RegistrationResult.Created:
                    return StatusCode(201, new { Message = "User registered successfully" });

                case RegistrationResult.UserAlreadyExists:
                    return Conflict(new { Message = "User already exists" });

                case RegistrationResult.Failed:
                default:
                    return StatusCode(500, new { Message = "Failed to register user" });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _userService.AuthenticateUserAsync(loginDto);
            if (!string.IsNullOrEmpty(token))
                return Ok(new { Token = token });
            return Unauthorized(new { Message = "Invalid credentials" });
        }
    }
}
