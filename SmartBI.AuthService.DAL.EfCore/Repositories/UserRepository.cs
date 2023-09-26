using Microsoft.EntityFrameworkCore;
using SmartBI.AuthService.DAL.EfCore.Contexts;
using SmartBI.AuthService.DAL.EfCore.Interfaces;
using SmartBI.AuthService.Domain.Entities;

namespace SmartBI.AuthService.DAL.EfCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public async Task Create(User user)
        {
            await _authDbContext.Users.AddAsync(user);
            await _authDbContext.SaveChangesAsync();
        }

        public async Task<User?> Get(int id)
        {
            return await _authDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> Get(string userName)
        {
            return await _authDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserName == userName);
        }
    }
}