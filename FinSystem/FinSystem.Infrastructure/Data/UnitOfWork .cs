using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Repositories;

namespace FinSystem.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private UserRepository? _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
