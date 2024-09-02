using AuthenticationAPI.Models;
using AuthenticationAPI.Services.AuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationManager _authService;
        public AuthenticateController(IAuthenticationManager authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = UserRoles.Admin)] // Only admins can register other admins
        public Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO model)
        {
            return _authService.RegisterAdmin(model);
        }

        [HttpPost]
        [Route("login-admin")]
        public Task<IActionResult> LoginAdmin([FromBody] LoginDTO model)
        {
            return _authService.LoginAdmin(model);
        }
    }
}
