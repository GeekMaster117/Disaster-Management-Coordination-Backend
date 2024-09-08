using AuthenticationAPI.Services.ValidationManager;
using DisasterManager.Data;
using DisasterManager.Models;
using DisasterManager.Services.AuthenticationManager;
using DisasterManager.Services.JwtManager;
using DisasterManager.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddScoped<IJwtManager, JwtManager>();
builder.Services.AddScoped<IValidationManager, ValidationManager>();

builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("UserDB"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IValidator<LoginDTO>, LoginDTOValidator>();
builder.Services.AddScoped<IValidator<RegisterDTO>, RegisterDTOValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(configurePolicy =>
{
	configurePolicy.AllowAnyOrigin();
    configurePolicy.AllowAnyHeader();
	configurePolicy.AllowAnyMethod();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
