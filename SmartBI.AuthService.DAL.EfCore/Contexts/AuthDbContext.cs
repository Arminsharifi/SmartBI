using Microsoft.EntityFrameworkCore;
using SmartBI.AuthService.DAL.EfCore.Mappings;
using SmartBI.AuthService.Domain.Entities;

namespace SmartBI.AuthService.DAL.EfCore.Contexts
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}