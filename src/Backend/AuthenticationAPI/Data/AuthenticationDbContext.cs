using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Data
{
	public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
		: IdentityDbContext<IdentityUser>(options)
	{
		DbSet<Volunteer> Volunteer { get; set; }
	}
}
