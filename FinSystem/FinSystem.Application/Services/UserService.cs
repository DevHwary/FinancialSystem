using FinSystem.Application.DTOs;
using FinSystem.Application.Interfaces;
using FinSystem.Domain.Entities;
using FinSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FinSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher, IJwtHandler jwtHandler)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtHandler = jwtHandler;
        }

        public async Task<bool> RegisterUserAsync(UserRegistrationDto userDto)
        {
            // TODO: to handle other cases such as "User already exists" 

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = _passwordHasher.HashPassword(null, userDto.Password),
                Role = "Admin" // Default role or use logic to assign roles
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<string> AuthenticateUserAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.FindByEmailAsync(loginDto.Email);

            if (user != null &&
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password) == PasswordVerificationResult.Success)
            {
                return _jwtHandler.CreateToken(user);
            }

            return null;
        }
    }
}
