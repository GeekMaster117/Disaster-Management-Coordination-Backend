using AuthenticationAPI.Services.ValidationManager;
using DisasterManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controller
{
	[ApiController]
	[Authorize(Roles = UserRoles.Admin)]
	public class ValidateController(IValidationManager validateService) : ControllerBase
	{
		private readonly IValidationManager _validateSerivce = validateService;

		[Route("validate")]
		[HttpGet]
		public IActionResult ValidateToken()
		{
			ResponseDTO response = _validateSerivce.TokenValidated();
			return StatusCode(response.StatusCode, response);
		}
	}
}
