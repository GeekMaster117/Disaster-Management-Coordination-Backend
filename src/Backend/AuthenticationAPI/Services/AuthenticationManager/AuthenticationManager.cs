using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using AuthenticationAPI.Models;
using Azure;
using AuthenticationAPI.Services.JwtManager;

namespace AuthenticationAPI.Services.AuthenticationManager
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtManager _jwtManager;

        public AuthenticationManager(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtManager jwtManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtManager = jwtManager;
        }

        public async Task<ResponseDTO> RegisterAdmin(RegisterDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new()
                {
                    StatusCode = ResponseMessages.BadRequest.StatusCode,
                    Message = "Username already exists"
                };

            ApplicationUser user = new()
            {
                UserName = model.Username,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new()
                {
                    StatusCode = ResponseMessages.InternalServerError.StatusCode,
                    Message = ResponseMessages.InternalServerError.Message
                };

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            return new()
            {
                StatusCode = ResponseMessages.Success.StatusCode,
                Message = "Admin Registered"
            };
        }

        public async Task<ResponseDTO> LoginAdmin(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                if(!userRoles.Contains(UserRoles.Admin))
					return new()
					{
						StatusCode = ResponseMessages.Unauthorized.StatusCode,
						Message = ResponseMessages.Unauthorized.Message
					};

				var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _jwtManager.GetToken(authClaims);

                return new()
                {
                    StatusCode = ResponseMessages.Success.StatusCode,
                    Message = new LoginResponse()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiry = token.ValidTo
                    }
                };
            }
            return new()
            {
                StatusCode = ResponseMessages.BadRequest.StatusCode,
                Message = "Username or Password is incorrect"
            };
        }
    }
}
