using FinSystem.Application.Interfaces.Data;
using FinSystem.Domain.Entities;
using FinSystem.Domain.Interfaces;
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
            List<User> users = _context.Users.ToList();
            var test = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            //var test = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return test;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}   
