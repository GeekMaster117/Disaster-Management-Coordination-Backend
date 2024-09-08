using DisasterManager.Models;

namespace AuthenticationAPI.Services.ValidationManager
{
	public interface IValidationManager
	{
		public ResponseDTO TokenValidated();
	}
}
