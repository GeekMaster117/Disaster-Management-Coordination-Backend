using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddCors();
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseCors(configurePolicy =>
{
    configurePolicy.WithOrigins("http://localhost:4200");
    configurePolicy.AllowAnyHeader();
    configurePolicy.AllowAnyMethod();
    configurePolicy.AllowCredentials();
});

app.UseWebSockets();

app.UseOcelot().Wait();

app.Run();
