using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartBI.AuthService.Application.Interfaces;
using SmartBI.AuthService.Domain.Commands;
using SmartBI.AuthService.Domain.Entities;
using SmartBI.AuthService.Domain.Queries;
using SmartBI.Shareds.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartBI.AuthService.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] SignInUserQuery signInUserQuery, [FromServices] IConfiguration configuration)
        {
            User? user = await _userServices.SignIn(signInUserQuery);
            if (user is not null)
            {
                JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString())
                    }),
                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWTSecurityKey"))), SecurityAlgorithms.HmacSha256)
                };
                SecurityToken securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
                return Ok(new JwtDto(securityTokenHandler.WriteToken(securityToken), (int)securityTokenDescriptor.Expires.Value.Subtract(DateTime.Now).TotalSeconds));
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpUserCommand signUpUserCommand)
        {
            try
            {
                await _userServices.SignUp(signUpUserCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }  
        }
    }
}