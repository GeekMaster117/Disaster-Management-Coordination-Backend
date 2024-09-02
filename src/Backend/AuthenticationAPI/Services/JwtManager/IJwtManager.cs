using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthenticationAPI.Services.JwtManager
{
    public interface IJwtManager
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
