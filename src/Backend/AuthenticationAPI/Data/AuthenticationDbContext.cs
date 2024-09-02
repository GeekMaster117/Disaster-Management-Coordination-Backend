using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Data
{
	public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
		: IdentityDbContext<IdentityUserCustom>(options)
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityUserCustom>().HasData(
				new IdentityUserCustom
				{
					Id = "1",
					UserName = "admin",
					NormalizedUserName = "ADMIN",
					PasswordHash = new PasswordHasher<IdentityUserCustom>().HashPassword(null, "admin")
				});
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "1",
					Name = AuthenticationAPI.Models.UserRoles.Admin,
					NormalizedName = AuthenticationAPI.Models.UserRoles.Admin.ToUpper()
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
