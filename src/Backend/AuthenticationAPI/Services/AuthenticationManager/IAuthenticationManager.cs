using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services.AuthenticationManager
{
    public interface IAuthenticationManager
    {
        Task<ResponseDTO> RegisterAdmin(RegisterDTO model);
        Task<ResponseDTO> LoginAdmin(LoginDTO model);
    }
}
