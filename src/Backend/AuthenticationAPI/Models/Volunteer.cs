using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationAPI.Models
{
	public class Volunteer
	{
		[ForeignKey("User")]
		public int Id { get; set; }
		public bool isVolunteer {  get; set; }
		public bool isEligible { get; set; }
		public IdentityUser User { get; set; } = new();
	}
}
