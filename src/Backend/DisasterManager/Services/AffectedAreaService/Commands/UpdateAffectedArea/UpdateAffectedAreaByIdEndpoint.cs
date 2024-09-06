using Carter;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Commands.UpdateAffectedArea
{
    public class UpdateAffectedAreaByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/affectedarea/{id:int}", async (int id, UpdateAffectedAreaByIdCommand command, IMediator mediator) =>
            {
                command.Id = id;
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
