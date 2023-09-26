using SmartBI.AuthService.Domain.Entities;

namespace SmartBI.AuthService.DAL.EfCore.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<User?> Get(int id);
        Task<User?> Get(string userName);
    }
}