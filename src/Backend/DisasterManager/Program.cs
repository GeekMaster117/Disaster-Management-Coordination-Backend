using Carter;
using DisasterManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddMediatR(configuration =>
{
	configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddDbContext<DisasterManagerDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("MapDB"));
});
builder.Services.AddCarter();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors(configuration =>
{
	configuration.AllowAnyOrigin();
	configuration.AllowAnyHeader();
	configuration.AllowAnyMethod();
});

app.MapCarter();

app.Run();
