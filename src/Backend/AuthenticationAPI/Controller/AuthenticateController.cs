using AuthenticationAPI.Models;
using AuthenticationAPI.Services.AuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        [Route("register/admin")]
        [Authorize(Roles = UserRoles.Admin)] // Only admins can register other admins
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO model)
        {
            var response = await _authService.RegisterAdmin(model);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginDTO model)
        {
            var response = await _authService.LoginAdmin(model);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
