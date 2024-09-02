using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Services
{
    public interface IAuthenticationManager
    {
        Task<IActionResult> RegisterAdmin(RegisterDTO model);
        Task<IActionResult> GetAllUsers();
    }
}
