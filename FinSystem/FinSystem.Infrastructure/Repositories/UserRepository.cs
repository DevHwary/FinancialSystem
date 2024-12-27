using FinSystem.Domain.Entities;
using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> FindByEmailAsync(string email)  
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}   
