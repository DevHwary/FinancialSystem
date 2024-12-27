using FinSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinSystem.Application.Interfaces.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
