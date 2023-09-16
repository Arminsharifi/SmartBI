using Microsoft.EntityFrameworkCore;
using SmartBI.AuthService.DAL.EfCore.Mappings;

namespace SmartBI.AuthService.DAL.EfCore.Contexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}