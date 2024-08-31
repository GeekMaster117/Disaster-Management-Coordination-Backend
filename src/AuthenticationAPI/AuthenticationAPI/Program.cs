using AuthenticationAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("UserDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
