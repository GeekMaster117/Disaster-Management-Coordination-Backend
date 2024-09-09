using DisasterManager.Models;
using Carter;
using DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaById;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace DisasterManager.Services.AffectedAreaService.Queries.GetAffectedArea.GetAffectedAreaByAreaId
{
	public class GetAffectedAreaByAreaIdEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapGet("/affectedarea/{id}", async ([FromRoute] int id, IMediator mediator) =>
			{
				var response = await mediator.Send(new GetAffectedAreaByAreaIdQuery()
				{
					AreaId = id
				});
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
