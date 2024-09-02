using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Models
{
	public class IdentityUserCustom : IdentityUser
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
	}
}
