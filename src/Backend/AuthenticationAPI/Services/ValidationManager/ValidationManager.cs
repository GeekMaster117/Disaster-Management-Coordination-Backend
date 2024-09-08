using AuthenticationAPI.Models;
using DisasterManager.Models;

namespace AuthenticationAPI.Services.ValidationManager
{
	public class ValidationManager : IValidationManager
	{
		public ResponseDTO TokenValidated()
		{
			return new()
			{
				StatusCode = DefaultMessages.Success.StatusCode,
				Message = ServiceMessages.TokenValid
			};
		}
	}
}
