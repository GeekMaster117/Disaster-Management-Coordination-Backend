using DisasterManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<DisasterManagerDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("MapDB"));
});

builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
