using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Services.AuthenticationManager
{
    public interface IAuthenticationManager
    {
        Task<IActionResult> RegisterAdmin(RegisterDTO model);
        Task<IActionResult> LoginAdmin(LoginDTO model);
    }
}
