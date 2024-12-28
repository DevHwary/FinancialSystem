using FinSystem.Application.DTOs;
using FinSystem.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegistrationResult> RegisterUserAsync(UserRegistrationDto userDto);
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
    }
}
