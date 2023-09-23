using SmartBI.AuthService.Application.Interfaces;
using SmartBI.AuthService.DAL.EfCore.Interfaces;
using SmartBI.AuthService.Domain.Commands;
using SmartBI.AuthService.Domain.Entities;
using SmartBI.AuthService.Domain.Queries;
using SmartBI.AuthService.Tools;

namespace SmartBI.AuthService.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SignUp(SignUpUserCommand signUpUserCommand)
        {
            string Salt = Security.CreateSalt();
            User user = new User
            {
                Name = signUpUserCommand.Name,
                UserName = signUpUserCommand.UserName.ToLower(),
                Password = Security.HashSha256WithSalt(signUpUserCommand.Password, Salt),
                Salt = Salt
            };
            await _userRepository.CreateUser(user);
        }

        public async Task<User?> SignIn(SignInUserQuery signInUserQuery)
        {
            User? user = await _userRepository.GetUser(signInUserQuery.UserName.ToLower());
            if (user is not null)
            {
                if (string.Equals(user.Password, Security.HashSha256WithSalt(signInUserQuery.Password, user.Salt)))
                {
                    return user;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}