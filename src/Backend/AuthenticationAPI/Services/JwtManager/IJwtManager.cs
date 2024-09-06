using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DisasterManager.Services.JwtManager
{
    public interface IJwtManager
    {
        public JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}
