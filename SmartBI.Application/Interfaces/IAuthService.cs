using SmartBI.Shareds.DataTransferObjects;

namespace SmartBI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<JwtDto> Authenticate(string UserName, string Password);
    }
}