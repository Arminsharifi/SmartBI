using SmartBI.Shareds.DataTransferObjects;

namespace SmartBI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<JwtDto?> AuthenticateAsync(string UserName, string Password);
    }
}