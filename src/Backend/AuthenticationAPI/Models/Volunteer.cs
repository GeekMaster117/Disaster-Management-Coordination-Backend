using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Models
{
	public class Volunteer : IdentityUser
	{
		public bool isVolunteer {  get; set; }
		public bool isEligible { get; set; }
	}
}
