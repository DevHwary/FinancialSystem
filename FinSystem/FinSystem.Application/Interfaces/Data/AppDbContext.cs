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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add additional configurations here if needed
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
