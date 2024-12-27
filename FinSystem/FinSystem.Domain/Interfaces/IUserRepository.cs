using FinSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
