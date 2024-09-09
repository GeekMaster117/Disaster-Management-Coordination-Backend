using Carter;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea
{
    public class UpdateAffectedAreaByIdEndpoint : ICarterModule
    {
		public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/affectedarea", async ([FromBody] UpdateAffectedAreaByIdCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);

                return Results.Content(
                    JsonSerializer.Serialize(response),
                    "application/json",
                    Encoding.UTF8,
                    response.StatusCode
                );
            })
			.RequireAuthorization(policy => policy.RequireRole(UserRoles.Admin));
        }
    }
}
