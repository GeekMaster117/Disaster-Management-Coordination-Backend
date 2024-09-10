using Carter;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdEndpoint : ICarterModule
    {
		public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/affectedarea", async ([FromBody] DeleteAffectedAreaByIdCommand command, IMediator mediator) =>
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
