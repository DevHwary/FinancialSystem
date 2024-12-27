using FinSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegistrationDto userDto);
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
    }
}
