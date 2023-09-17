using SmartBI.AuthService.Domain.Commands;
using SmartBI.AuthService.Domain.Entities;
using SmartBI.AuthService.Domain.Queries;

namespace SmartBI.AuthService.Application.Interfaces
{
    public interface IUserServices
    {
        Task<User?> SignIn(SignInUserQuery signInUserQuery);
        Task SignUp(SignUpUserCommand signUpUserCommand);
    }
}