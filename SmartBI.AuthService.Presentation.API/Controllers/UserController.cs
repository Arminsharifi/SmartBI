using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBI.AuthService.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SmartBI.AuthService.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required][MinLength(5)][MaxLength(70)] string UserName)
        {
            var user = await _userServices.Get(UserName);
            return user is not null ? Ok(user) : NotFound();
        }
    }
}