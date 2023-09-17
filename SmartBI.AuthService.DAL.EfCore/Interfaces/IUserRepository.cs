using SmartBI.AuthService.Domain.Entities;

namespace SmartBI.AuthService.DAL.EfCore.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User?> GetUser(int id);
        Task<User?> GetUser(string userName);
    }
}