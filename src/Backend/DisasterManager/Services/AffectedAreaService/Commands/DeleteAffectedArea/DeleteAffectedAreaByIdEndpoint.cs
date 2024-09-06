using Carter;
using DisasterManager.Models;
using DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace DisasterManager.Services.AffectedAreaService.Commands.DeleteAffectedArea
{
    public class DeleteAffectedAreaByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/affectedarea/{id:int}", async (int id, IMediator mediator) =>
            {
                var command = new DeleteAffectedAreaByIdCommand { Id = id };
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
