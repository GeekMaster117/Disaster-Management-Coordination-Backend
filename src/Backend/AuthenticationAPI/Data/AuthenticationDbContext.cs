using DisasterManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Data
{
	public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
		: IdentityDbContext<ApplicationUser>(options)
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Id = "1",
					UserName = "admin",
					NormalizedUserName = "ADMIN",
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "admin")
				});
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "1",
					Name = DisasterManager.Models.UserRoles.Admin,
					NormalizedName = DisasterManager.Models.UserRoles.Admin.ToUpper()
				});
			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = "1",
					UserId = "1"
				});
		}
	}
}
