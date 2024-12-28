using FinSystem.Application.DTOs;
using FinSystem.Application.Enums;
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

        public async Task<RegistrationResult> RegisterUserAsync(UserRegistrationDto userDto)
        {
            var existingUser = await _unitOfWork.Users.FindByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return RegistrationResult.UserAlreadyExists;
            }

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = _passwordHasher.HashPassword(null, userDto.Password),
                Role = "Admin"
            };

            try
            {
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CommitAsync();
                return RegistrationResult.Created;
            }
            catch (Exception)
            {
                return RegistrationResult.Failed;
            }
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
