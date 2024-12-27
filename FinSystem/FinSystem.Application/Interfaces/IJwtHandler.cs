using FinSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Application.Interfaces
{
    public interface IJwtHandler
    {
        string CreateToken(User user);
    }
}
