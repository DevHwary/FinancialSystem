using FinSystem.Application.DTOs;
using FinSystem.Application.Interfaces;
using FinSystem.Domain.Entities;
using FinSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FinSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtHandler = jwtHandler;
        }

        public async Task<bool> RegisterUserAsync(UserRegistrationDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = _passwordHasher.HashPassword(null, userDto.Password),
                Role = "Admin" // Default role or use logic to assign roles
            };

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<string> AuthenticateUserAsync(LoginDto loginDto)
        {
            var user = await _userRepository.FindByEmailAsync(loginDto.Email);
            if (user != null && _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password) == PasswordVerificationResult.Success)
            {
                return _jwtHandler.CreateToken(user);
            }
            return null;
        }
    }
}
