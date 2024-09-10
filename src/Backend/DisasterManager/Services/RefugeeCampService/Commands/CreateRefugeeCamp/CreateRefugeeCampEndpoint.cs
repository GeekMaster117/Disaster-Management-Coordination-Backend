using Carter;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Commands.CreateAffectedArea;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.RefugeeCampService.Commands.CreateRefugeeCamp
{
	public class CreateRefugeeCampEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("/refugeecamp", async ([FromBody] CreateRefugeeCampCommand command, IMediator mediator) =>
			{
				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};
				var response = await mediator.Send(command);
				return Results.Content(
					JsonSerializer.Serialize(response, options),
					"application/json",
					Encoding.UTF8,
					response.StatusCode
				);
			})
			.RequireAuthorization(policy => policy.RequireRole(UserRoles.Admin));
		}
	}
}
