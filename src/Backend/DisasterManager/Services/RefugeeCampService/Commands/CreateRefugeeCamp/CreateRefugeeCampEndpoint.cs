using Carter;
using DisasterManager.Services.AffectedAreaService.Commands.CreateAffectedArea;
using MediatR;
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
				var response = await mediator.Send(command);
				return Results.Content(
					JsonSerializer.Serialize(response),
					"application/json",
					Encoding.UTF8,
					response.StatusCode
				);
			});
		}
	}
}
