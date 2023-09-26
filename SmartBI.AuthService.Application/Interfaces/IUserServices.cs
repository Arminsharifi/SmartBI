using SmartBI.AuthService.Domain.Commands;
using SmartBI.AuthService.Domain.Entities;
using SmartBI.AuthService.Domain.Queries;
using SmartBI.Shareds.DataTransferObjects;

namespace SmartBI.AuthService.Application.Interfaces
{
    public interface IUserServices
    {
        Task<User?> SignIn(SignInUserQuery signInUserQuery);
        Task SignUp(SignUpUserCommand signUpUserCommand);
        Task<UserDto?> Get(string UserName);
    }
}