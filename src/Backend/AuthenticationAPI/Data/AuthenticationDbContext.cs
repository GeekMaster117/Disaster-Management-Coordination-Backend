﻿using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Data
{
	public class AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
		: IdentityDbContext<IdentityUser>(options)
	{
		protected virtual void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityUser>().HasData(
				new IdentityUser
				{
					Id = "1",
					UserName = "admin",
					PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
				});
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Id = "1",
					Name = AuthenticationAPI.Models.UserRoles.Admin
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
